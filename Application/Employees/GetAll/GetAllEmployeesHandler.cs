using Application.Employees.GetAll;
using Domain.Interfaces;
using MediatR;

namespace Application.Employees.Queries;

public class GetAllEmployeesHandler
    : IRequestHandler<GetAllEmployeesQuery, IEnumerable<Employee>>
{
    private readonly IEmployeeRepository _repository;

    public GetAllEmployeesHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Employee>> Handle(
        GetAllEmployeesQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync(cancellationToken);
    }
}
