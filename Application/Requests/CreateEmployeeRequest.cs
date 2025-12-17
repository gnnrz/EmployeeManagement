using Domain.Enums;

namespace Application.Employees.Create;

public class CreateEmployeeRequest
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Document { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public Role Role { get; set; }
    public Guid? ManagerId { get; set; }
    public List<string> Phones { get; set; } = new();

    public CreateEmployeeCommand ToCommand()
        => new(
            FirstName,
            LastName,
            Email,
            Document,
            BirthDate,
            Role,
            ManagerId,
            Phones
        );
}