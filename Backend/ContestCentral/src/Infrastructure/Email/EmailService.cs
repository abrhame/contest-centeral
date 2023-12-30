using ContestCentral.Application.Common.Interfaces;
using ContestCentral.Application.Common.Models;

using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Logging;


namespace ContestCentral.Infrastructure.Email;

public class EmailService : IEmailService {
    private readonly EmailSettings _emailSettings;
    private readonly ILogger _logger;

    public EmailService(IOptions<EmailSettings> emailSettings, ILogger<EmailService> logger) {
        _emailSettings = emailSettings.Value;
        _logger = logger;
    }

    public async Task<Result> SendEmailAsync(string address, string subject, string body) {
        try {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_emailSettings.DefaultFromEmail));
            email.To.Add(MailboxAddress.Parse(address));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_emailSettings.UserName, _emailSettings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
            return Result.SuccessResult("Email sent successfully");
        } catch (Exception ex) {
            _logger.LogError(ex, "Error sending email to {address}", address);
            return Result.FailureResult(new string[] { ex.Message });
        }
    }

    public Task<Result> SendBatchEmailAsync(IEnumerable<string> addresses, string subject, string body) {
        throw new NotImplementedException();
    }
}
