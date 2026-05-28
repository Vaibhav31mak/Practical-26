namespace Practical26.Application.Features.Employees.Commands
{
    public record CreateEmployeeCommand(
        string Name,
        decimal Salary,
        int DepartmentId,
        string EmailId
    ) : CreateEmployeeModel(Name, Salary, DepartmentId, EmailId), IRequest<int>;
}
