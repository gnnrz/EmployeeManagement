using Domain.Entities;
using Domain.Enums;

namespace Application.Employees.Create;

public record CreateEmployeeRequest(
    string FirstName,
    string LastName,
    string Email,
    string Document,
    DateTime BirthDate,
    Role Role,
    Guid? ManagerId,
    List<string> Phones,
    string Password
)
{
    public CreateEmployeeCommand ToCommand()
        => new CreateEmployeeCommand(
            FirstName,
            LastName,
            Email,
            Document,
            BirthDate,
            Role,
            ManagerId,
            Phones
                .Select(p => new Phone(p))
                .ToList(),
            Password
        );
}