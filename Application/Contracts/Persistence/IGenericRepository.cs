namespace HRLeaveManagement.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : class
{
    Task<T> CreateAsync(T entity);
    Task<T> UpdatedAsync(T entity);
    Task<T> DeleteAsync(T entity);
    Task<List<T>> GetAsync();
    Task<T> GetByIdAsync(int id);
}
