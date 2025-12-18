using MediatR;

namespace Application.Employees.GetById;

public record GetEmployeeByIdQuery(Guid Id)
    : IRequest<Employee?>;