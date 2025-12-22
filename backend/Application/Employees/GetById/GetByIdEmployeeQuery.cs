using MediatR;

namespace Application.Employees.GetById;

public record GetByIdEmployeeQuery(Guid Id)
    : IRequest<EmployeeResponse?>;
