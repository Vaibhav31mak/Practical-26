namespace Practical26.Application.CommandModels;

public record UpdateEmployeeModel(
    string Name,
    decimal Salary,
    int DepartmentId,
    string EmailId
);
