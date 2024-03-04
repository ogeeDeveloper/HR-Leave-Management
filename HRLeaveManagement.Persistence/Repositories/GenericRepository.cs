using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HRLeaveManagement.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly HRDatabaseContext _dbContext;

        public GenericRepository(HRDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync()
        {
           return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdatedAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified; // Mark it as modified
            await _dbContext.SaveChangesAsync();
        }
    }
}
