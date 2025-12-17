using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Rules;

public static class EmployeeRules
{
    public static void ValidateAge(DateTime birthDate)
    {
        var today = DateTime.Today;
        var age = today.Year - birthDate.Year;

        if (birthDate.Date > today.AddYears(-age))
            age--;

        if (age < 18)
            throw new DomainException("Employee must be at least 18 years old.");
    }

    public static void ValidateRoleCreation(Role currentUserRole, Role newEmployeeRole)
    {
        if (newEmployeeRole > currentUserRole)
            throw new DomainException(
                "You cannot create an employee with higher permission than yours.");
    }
}
