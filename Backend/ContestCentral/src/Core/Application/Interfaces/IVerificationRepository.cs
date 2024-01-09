using Domain.Entity;

namespace Application.Interfaces;

public interface IVerificationRepository : IGenericRepository<Verification>
{
    Task<Verification?> GetByTokenAsync(string token);
    Task<Verification?> GetByUserIdAsync(Guid userId);
    Task<Verification?> GetByUserIdAndTypeAsync(Guid userId, VerificationType type);
}
