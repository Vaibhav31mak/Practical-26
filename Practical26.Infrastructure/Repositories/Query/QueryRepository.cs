namespace Practical26.Infrastructure.Repositories.Query;

// Separate query repository is implemented to adhere to the CQRS pattern.
// AsNoTracking is used for query operations to improve performance.
public sealed class QueryRepository<T>(ApplicationDbContext context)
    : IQueryRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet = context.Set<T>();

    /// <summary>
    /// Gets an entity by its ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Returns Entity</returns>
    public async Task<T?> GetByIdAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if(entity is null)
            return null;
        if(entity is IStatus statusEntity && !statusEntity.Status)
            return null;
        return entity;
    }

    /// <summary>
    /// Gets all active entities.
    /// </summary>
    /// <returns>Returns a list of all active entities</returns>
    public async Task<List<T>> GetAllAsync()
        => await _dbSet
            .AsNoTracking()
            .Where(entity => EF.Property<bool>(entity, "Status"))
            .ToListAsync();
}
