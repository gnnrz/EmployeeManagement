using MediatR;

namespace Application.Employees.GetAll;

public record GetAllEmployeesQuery() : IRequest<IEnumerable<Employee>>;