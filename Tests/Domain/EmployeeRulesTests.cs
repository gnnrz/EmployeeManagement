using Domain.Enums;
using Domain.Exceptions;

namespace Tests.Domain;

public class EmployeeRulesTests
{
    [Fact]
    public void Should_throw_exception_when_user_creates_higher_role()
    {
        // Arrange
        var currentUserRole = Role.Employee;
        var newEmployeeRole = Role.Leader;

        // Act
        var action = () =>
            EmployeeRules.ValidateRoleHierarchy(
                currentUserRole,
                newEmployeeRole
            );

        // Assert
        Assert.Throws<DomainException>(action);
    }

    [Fact]
    public void Should_allow_creation_when_role_is_equal_or_lower()
    {
        // Arrange
        var currentUserRole = Role.Leader;
        var newEmployeeRole = Role.Employee;

        // Act (no exception)
        EmployeeRules.ValidateRoleHierarchy(
            currentUserRole,
            newEmployeeRole
        );

        // Assert
        Assert.True(true);
    }
}
