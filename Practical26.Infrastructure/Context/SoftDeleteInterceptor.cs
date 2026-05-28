namespace Practical26.Infrastructure.Context;

public class SoftDeleteInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is null) 
            return base.SavingChangesAsync(eventData, result, cancellationToken);

        var entries = eventData.Context.ChangeTracker
            .Entries<IStatus>()
            .Where(e => e.State == EntityState.Deleted);

        foreach(var entry in entries)
        {
            entry.State = EntityState.Modified;
            entry.Entity.Status = false;
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
