using HRLeaveManagement.Domain.Common;

namespace HRLeaveManagement.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task CreateAsync(T entity);
    Task UpdatedAsync(T entity);
    Task DeleteAsync(T entity);
    Task<IReadOnlyList<T>> GetAsync();
    Task<T> GetByIdAsync(int id);
}
