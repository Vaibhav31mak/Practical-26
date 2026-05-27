namespace Practical26.Infrastructure.UnitOfWork;

// The separate UnitOfWork is made only for command operations because the query operations
// technically do not require a unit of work as they are read-only and do not involve
// transactions. 
public interface ICommandUnitOfWork
{
    ICommandRepository<Employee> Employees { get; }
    Task<int> SaveChangesAsync();
}
