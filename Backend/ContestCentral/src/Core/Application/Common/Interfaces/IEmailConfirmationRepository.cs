using ContestCentral.Application.Common.Models;

namespace ContestCentral.Application.Common.Interfaces;

public interface IEmailConfirmationRepository {
    Task<Result> AddEmailConfirmationAsync(string code, Guid userId);
    Task<(Result, string?)> GetEmailConfirmationByCodeAsync(string code);
    Task<(Result, string?)> GetEmailConfirmationByUserIdAsync(Guid userId);
    Task DeleteEmailConfirmationAsync(string code);
}
