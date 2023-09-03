using MailKit.Security;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

using Wego.Application.Models.Mail;
using Wego.Application.Contracts.Common;
using Wego.Domain.Mail;

namespace Wego.Application.Features.Common
{
    public class EmailSender : IEmailSender
    { 
    private readonly EmailSettings _emailSettings;
    public EmailSender(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }

    public async Task<bool> SendMailAsync(Email mailData, CancellationToken ct = default)
    {

        try
        {
            // Initialize a new instance of the MimeKit.MimeMessage class
            var mail = new MimeMessage();

            #region Sender / Receiver
            // Sender
            mail.From.Add(new MailboxAddress(_emailSettings.DisplayName, mailData.From ?? _emailSettings.From));
            mail.Sender = new MailboxAddress(mailData.DisplayName ?? _emailSettings.DisplayName, mailData.From ?? _emailSettings.From);

            // Receiver
            foreach (string mailAddress in mailData.To)
                mail.To.Add(MailboxAddress.Parse(mailAddress));

            // Set Reply to if specified in mail data
            if (!string.IsNullOrEmpty(mailData.ReplyTo))
                mail.ReplyTo.Add(new MailboxAddress(mailData.ReplyToName, mailData.ReplyTo));

            // BCC
            // Check if a BCC was supplied in the request
            if (mailData.Bcc?.Any() == true)
            {
                // Get only addresses where value is not null or with whitespace. x = value of address
                foreach (string mailAddress in mailData.Bcc.Where(x => !string.IsNullOrWhiteSpace(x)))
                    mail.Bcc.Add(MailboxAddress.Parse(mailAddress.Trim()));
            }

            // CC
            // Check if a CC address was supplied in the request
            if (mailData.Cc?.Any() == true)
            {
                foreach (string mailAddress in mailData.Cc.Where(x => !string.IsNullOrWhiteSpace(x)))
                    mail.Cc.Add(MailboxAddress.Parse(mailAddress.Trim()));
            }
            #endregion

            #region Content

            // Add Content to Mime Message
            var body = new BodyBuilder();
            mail.Subject = mailData.Subject;
            body.HtmlBody = mailData.Body;

            if (mailData.Attachments?.Any() == true)
            {
                foreach (var attachment in mailData.Attachments)
                {
                    body.Attachments.Add(attachment.FileName, attachment.OpenReadStream(), ct);
                }
            }
            mail.Body = body.ToMessageBody();

            #endregion

            #region Send Mail

            using var smtp = new SmtpClient();

            if (_emailSettings.UseSSL)
            {
                await smtp.ConnectAsync(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.SslOnConnect, ct);
            }
            else if (_emailSettings.UseStartTls)
            {
                await smtp.ConnectAsync(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls, ct);
            }
            await smtp.AuthenticateAsync(_emailSettings.Username, _emailSettings.Password, ct);
            await smtp.SendAsync(mail, ct);
            await smtp.DisconnectAsync(true, ct);

            #endregion

            return true;

        }
        catch (Exception)
        {
            return false;
        }
    }
}
}
