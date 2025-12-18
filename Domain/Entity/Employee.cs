using Domain.Entities;
using Domain.Enums;

public class Employee
{
    private readonly List<Phone> _phones = new();

    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Document { get; private set; }
    public DateTime BirthDate { get; private set; }
    public Role Role { get; private set; }
    public Guid? ManagerId { get; private set; }
    public string PasswordHash { get; private set; }

    public IReadOnlyCollection<Phone> Phones => _phones;

    protected Employee() { }

    private void AddPhones(IEnumerable<Phone> phones)
    {
        _phones.AddRange(phones);
    }

    public static Employee Create(
        string firstName,
        string lastName,
        string email,
        string document,
        DateTime birthDate,
        Role role,
        Guid? managerId,
        IEnumerable<Phone> phones,
        string passwordHash
    )
    {
        EmployeeRules.ValidateAge(birthDate);
        EmployeeRules.ValidatePhones(phones);
        EmployeeRules.ValidatePasswordHash(passwordHash);

        var employee = new Employee
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Document = document,
            BirthDate = birthDate,
            Role = role,
            ManagerId = managerId,
            PasswordHash = passwordHash
        };

        employee.AddPhones(phones);

        return employee;
    }
}
