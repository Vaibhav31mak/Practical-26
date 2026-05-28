namespace Practical26.Infrastructure.UnitOfWork;

// The separate UnitOfWork is made only for command operations because the query operations
// technically do not require a unit of work as they are read-only and do not involve transactions.
public sealed class CommandUnitOfWork(ApplicationDbContext context) : ICommandUnitOfWork
{
    private readonly ApplicationDbContext _context = context;
    private ICommandRepository<Employee>? _employees;

    public ICommandRepository<Employee> Employees => _employees ??=
        new CommandRepository<Employee>(_context);

    public Task<int> SaveChangesAsync()
        => _context.SaveChangesAsync();
}
