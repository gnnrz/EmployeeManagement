using MediatR;
using CSharpFunctionalExtensions;
using Domain.Enums;

namespace Application.Employees.Create;

public record CreateEmployeeCommand(
    string FirstName,
    string LastName,
    string Email,
    string Document,
    DateTime BirthDate,
    Role Role,
    Guid? ManagerId,
    List<string> Phones
) : IRequest<Result<Guid>>;