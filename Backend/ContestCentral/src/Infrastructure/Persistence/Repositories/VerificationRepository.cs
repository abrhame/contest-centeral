using Microsoft.EntityFrameworkCore;

using Application.Interfaces;
using Domain.Entity;

namespace Infrastructure.Persistence.Repositories;

public class VerificationRepository : GenericRepository<Verification>, IVerificationRepository
{
    private readonly ContestCentralDbContext _context;
    public VerificationRepository(ContestCentralDbContext context) : base(context){
        _context = context;
    }

    public async Task<Verification?> GetByTokenAsync(string token)
    {
        return await _context.Verifications.FirstOrDefaultAsync(x => x.Token == token);
    }

    public async Task<Verification?> GetByUserIdAsync(Guid userId)
    {
        return await _context.Verifications.FirstOrDefaultAsync(x => x.UserId == userId);
    }

    public async Task<Verification?> GetByUserIdAndTypeAsync(Guid userId, VerificationType type)
    {
        return await _context.Verifications.FirstOrDefaultAsync(x => x.UserId == userId && x.VerificationType == type);
    }

}
