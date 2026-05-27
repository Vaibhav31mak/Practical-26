namespace Practical26.Application.Features.Employees.Queries
{
    public sealed record GetAllEmployeesQuery()
        : IRequest<IReadOnlyList<EmployeeResponse>>;
}
