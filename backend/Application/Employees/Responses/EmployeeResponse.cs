using Domain.Enums;

public record EmployeeResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Document,
    Role Role,
    Guid? ManagerId,
    List<string> Phones
);