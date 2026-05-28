namespace Practical26.Application.Features.Employees.Queries
{
    public record GetEmployeeByIdQuery(int Id) : IRequest<EmployeeResponseModel>;
}
