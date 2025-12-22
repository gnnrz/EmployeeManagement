using MediatR;

namespace Application.Employees.GetAll;

public record GetAllEmployeesQuery
    : IRequest<List<EmployeeResponse>>;