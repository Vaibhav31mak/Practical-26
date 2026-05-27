namespace Practical26.Application.CommandModels;

public record CreateEmployeeModel(
    string Name,
    decimal Salary,
    int DepartmentId,
    string EmailId
);
