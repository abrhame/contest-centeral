using ContestCentral.Application.Common.Interfaces;
using ContestCentral.Domain.Common.Entity;
using ContestCentral.Application.Common.Models;

using Microsoft.EntityFrameworkCore;

namespace ContestCentral.Infrastructure.Persistence.Repositories;

public class EmailConfirmationRepository : IEmailConfirmationRepository {
    private readonly ContestCentralDbContext _dbContext;

    public EmailConfirmationRepository(ContestCentralDbContext dbContext) {
        _dbContext = dbContext;
    }

    public async Task<Result> AddEmailConfirmationAsync(string code, Guid userId) {
        try {
            await _dbContext.EmailConfirmations.AddAsync(
                new EmailConfirmation {
                    Code = code,
                    UserId = userId
                });

            await _dbContext.SaveChangesAsync();
            return Result.SuccessResult("Email confirmation added successfully.");
        } catch (Exception) {
            return Result.FailureResult(new List<string> { "Failed to add email confirmation." });
        }
    }

    public async Task<(Result, string?)> GetEmailConfirmationByCodeAsync(string code) {
        var emailConfirmation = await _dbContext.EmailConfirmations
            .FirstOrDefaultAsync(e => e.Code == code);

        if (emailConfirmation == null) {
            return (Result.FailureResult(new List<string> { "Email confirmation not found." }), null);
        }

        return (Result.SuccessResult("Confirmation code Found"), emailConfirmation.Code);
    }

    public async Task<(Result, string?)> GetEmailConfirmationByUserIdAsync(Guid userId) {
        var emailConfirmation = await _dbContext.EmailConfirmations
            .FirstOrDefaultAsync(e => e.UserId == userId);

        if (emailConfirmation == null) {
            return (Result.FailureResult(new List<string> { "Email confirmation not found." }), null);
        }

        return (Result.SuccessResult("Confirmation code Found"), emailConfirmation.Code);
    }

    public async Task DeleteEmailConfirmationAsync(string code) {
        var emailConfirmation = await _dbContext.EmailConfirmations
            .FirstOrDefaultAsync(e => e.Code == code);

        if (emailConfirmation == null) {
            return;
        }

        _dbContext.EmailConfirmations.Remove(emailConfirmation);
        await _dbContext.SaveChangesAsync();
    }
}
