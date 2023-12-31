using ContestCentral.Application.Common.Models;

namespace ContestCentral.Application.Common.Interfaces;

public interface IEmailService {
    public Task<Result> SendEmailAsync(string toAddress, string subject, string body, string? fromAddress);
    public Task<Result> SendBatchEmailAsync(IEnumerable<string> toAddresses, string subject, string body, string? fromAddress); 
}
