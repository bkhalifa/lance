namespace Wego.Domain.Mail;

public class EmailSettings
{
    public string Host { get; set; }
    public int Port { get; set; }
    public string From { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string DisplayName { get; set; }
    public string ErrorEmails { get; set; }
    public bool UseSSL { get; set; }
    public bool UseStartTls { get; set; }
}

