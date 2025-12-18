using MediatR;
using CSharpFunctionalExtensions;
using Domain.Enums;
using Domain.Entities;

namespace Application.Employees.Create;

public record CreateEmployeeCommand(
    string FirstName,
    string LastName,
    string Email,
    string Document,
    DateTime BirthDate,
    Role Role,
    Guid? ManagerId,
    List<Phone> Phones,
    string Password
) : IRequest<Result<Guid>>;