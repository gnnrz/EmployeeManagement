using Domain.Enums;
using System.Data;

namespace Domain.Entities;

public class Employee
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Document { get; private set; }
    public DateTime BirthDate { get; private set; }
    public Role Role { get; private set; }
    public Guid? ManagerId { get; private set; }
    public List<Phone> Phones { get; private set; }

    private Employee() { }

    public static Employee Create(
        string firstName,
        string lastName,
        string email,
        string document,
        DateTime birthDate,
        Role role,
        Guid? managerId,
        List<string> phones)
    {
        return new Employee
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Document = document,
            BirthDate = birthDate,
            Role = role,
            ManagerId = managerId,
            Phones = phones.Select(p => new Phone(p)).ToList()
        };
    }
}