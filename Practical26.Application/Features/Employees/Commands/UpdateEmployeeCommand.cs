namespace Practical26.Application.Features.Employees.Commands
{
    public record UpdateEmployeeCommand(
        int Id,
        string Name,
        decimal Salary,
        int DepartmentId,
        string EmailId,
        bool Status
    ) : UpdateEmployeeModel(Name, Salary, DepartmentId, EmailId), IRequest<int>;

}