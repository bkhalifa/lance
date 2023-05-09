﻿using Microsoft.AspNetCore.Http;

namespace Wego.Application.Models.Mail
{
    public class Email
    {
        // Receiver separted by
        public List<string> To { get; }
        public List<string> Bcc { get; }

        public List<string> Cc { get; }

        // Sender
        public string From { get; }

        public string DisplayName { get; }

        public string ReplyTo { get; }

        public string ReplyToName { get; }

        // Content
        public string Subject { get; }

        public string Body { get; }
        public List<IFormFile> Attachments { get; set; }

        public Email(string to, string subject, string body = null, string from = null, string displayName = null,
            string replyTo = null, string replyToName = null, List<string> bcc = null, List<string> cc = null, List<IFormFile> attachments = null)
        {
            // Receiver
            To = to.Split(';').ToList();
            Bcc = bcc ?? new List<string>();
            Cc = cc ?? new List<string>();

            // Sender
            From = from;
            DisplayName = displayName;
            ReplyTo = replyTo;
            ReplyToName = replyToName;

            // Content
            Subject = subject;
            Body = body;
            Attachments = attachments ?? new List<IFormFile>();
        }
    }
}
