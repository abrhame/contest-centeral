using ContestCentral.Application.Common.Models;

namespace ContestCentral.Application.Common.Interfaces;

public interface IEmailService {
    public Task<Result> SendEmailAsync(string address, string subject, string body);
    public Task<Result> SendBatchEmailAsync(IEnumerable<string> addresses, string subject, string body); 
}
