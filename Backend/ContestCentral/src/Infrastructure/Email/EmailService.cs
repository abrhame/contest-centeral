using Application.Interfaces;
using Application.Common.Models;
using Application.DTOs;

using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Email;

public class EmailService : IEmailService {
    private readonly EmailSettings _emailSettings;
    private readonly Microsoft.Extensions.Logging.ILogger _logger;

    public EmailService(IOptions<EmailSettings> emailSettings, Microsoft.Extensions.Logging.ILogger logger) {
        _emailSettings = emailSettings.Value;
        _logger = logger;
    }

    public async Task<Result> SendAsync(EmailMetadata request) {
        try {
            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_emailSettings.DefaultFromEmail, _emailSettings.Password);

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_emailSettings.DefaultFromEmail));

            foreach (var address in request.Emails) {
                email.To.Add(MailboxAddress.Parse(address));
                email.Subject = request.Subject;
                email.Body = new TextPart(TextFormat.Html) { Text = request.Message };
                await smtp.SendAsync(email);
            }

            await smtp.DisconnectAsync(true);

            return Result.SuccessResult("Email sent successfully");
        } catch (Exception ex) {
            _logger.LogError(ex.Message);
            return Result.FailureResult(new string[] { ex.Message });
        }
    }
}
