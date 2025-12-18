using Domain.Enums;
using Domain.Entities;

namespace Application.Employees.Update;

public record UpdateEmployeeRequest(
    string FirstName,
    string LastName,
    string Email,
    string Document,
    DateTime BirthDate,
    Role Role,
    Guid? ManagerId,
    List<string> Phones
)
{
    public UpdateEmployeeCommand ToCommand(Guid id)
        => new UpdateEmployeeCommand(
            id,
            FirstName,
            LastName,
            Email,
            Document,
            BirthDate,
            Role,
            ManagerId,
            Phones.Select(p => new Phone(p)).ToList()
        );
}
