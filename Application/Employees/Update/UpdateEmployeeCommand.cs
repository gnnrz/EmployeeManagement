using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Employees.Update;

public record UpdateEmployeeCommand(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Document,
    DateTime BirthDate,
    Role Role,
    Guid? ManagerId,
    List<Phone> Phones
) : IRequest<bool>;