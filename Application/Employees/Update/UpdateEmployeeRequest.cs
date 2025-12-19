using Domain.Enums;

namespace Application.Employees.Update;

public record UpdateEmployeeRequest(
    string FirstName,
    string LastName,
    string Email,
    Role Role,
    Guid? ManagerId,
    List<string> Phones
)
{
    public UpdateEmployeeCommand ToCommand(Guid id)
        => new(
            id,
            FirstName,
            LastName,
            Email,
            Role,
            ManagerId,
            Phones
        );
}
