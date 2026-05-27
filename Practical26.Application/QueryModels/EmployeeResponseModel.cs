namespace Practical26.Application.QueryModels;

public record EmployeeResponseModel(
    int Id,
    string Name,
    decimal Salary,
    int DepartmentId,
    string EmailId,
    DateTime JoiningDate,
    bool Status
);
