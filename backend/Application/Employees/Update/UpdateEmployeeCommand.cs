using MediatR;
using CSharpFunctionalExtensions;
using Domain.Enums;

namespace Application.Employees.Update;

public record UpdateEmployeeCommand(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    Role Role,
    Guid? ManagerId,
    List<string> Phones
) : IRequest<Result>;