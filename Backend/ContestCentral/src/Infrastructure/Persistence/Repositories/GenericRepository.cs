using Microsoft.EntityFrameworkCore;

using ContestCentral.Application.Common.Interfaces;

namespace ContestCentral.Infrastructure.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class {
    private readonly ContestCentralDbContext _dbContext;

    protected GenericRepository(ContestCentralDbContext dbContext) {
        _dbContext = dbContext;
    }

    public async Task<T> AddAsync(T entity) {
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> ExistsAsync(Guid id) {
        var entity = await GetAsync(id);
        return entity != null;
    }

    public Task DeleteAsync(T entity) {
        _dbContext.Set<T>().Remove(entity);
        _dbContext.SaveChangesAsync();
        return Task.CompletedTask;
    }

    public async Task<T?> GetAsync(Guid id) {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> GetAllAsync() {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public Task UpdateAsync(T entity) {
        _dbContext.Entry(entity).State = EntityState.Modified;
        _dbContext.SaveChangesAsync();
        return Task.CompletedTask;
    }
}
