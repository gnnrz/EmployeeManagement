using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;

public static class EmployeeRules
{
    public static void ValidateAge(DateTime birthDate)
    {
        var age = DateTime.Today.Year - birthDate.Year;
        if (birthDate > DateTime.Today.AddYears(-age)) age--;

        if (age < 18)
            throw new DomainException("Employee must be at least 18 years old.");
    }

    public static void ValidatePhones(IEnumerable<Phone> phones)
    {
        if (phones == null || phones.Count() < 2)
            throw new DomainException("Employee must have at least two phone numbers.");
    }

    public static void ValidatePasswordHash(string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new DomainException("Password hash is required.");
    }

    public static void ValidateRoleHierarchy(Role creatorRole, Role newEmployeeRole)
    {
        if (newEmployeeRole > creatorRole)
            throw new DomainException("You cannot create an employee with a higher role than yours.");
    }
}
