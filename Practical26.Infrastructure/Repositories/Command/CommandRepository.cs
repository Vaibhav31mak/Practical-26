namespace Practical26.Infrastructure.Repositories.Command;

public sealed class CommandRepository<T>(ApplicationDbContext context)
    : ICommandRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task AddAsync(T entity)
        => await _dbSet.AddAsync(entity);

    public void Update(T entity)
        => _dbSet.Update(entity);

    // Soft delete by setting a "Status" property to false
    /// <summary>
    /// Soft deletes an entity by setting its "Status" property to false.
    /// </summary>
    /// <param name="id">The ID of the entity to delete.</param>
    /// <exception cref="InvalidOperationException">Thrown if the entity is not found.</exception>
    public void Delete(int id)
    {
        var entity = _dbSet.Find(id)
            ?? throw new InvalidOperationException(
                $"Entity of type {typeof(T).Name} with id {id} not found.");

        if(entity is IStatus employee)
        {
            employee.Status = false;
            _dbSet.Update(entity);
        }
    }
}
