namespace Practical26.Infrastructure.Repositories.Query;

public interface IQueryRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
}
