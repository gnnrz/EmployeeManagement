using Application.Employees.GetAll;
using Domain.Interfaces;
using MediatR;

namespace Application.Employees.Queries;

public class GetAllEmployeesHandler
    : IRequestHandler<GetAllEmployeesQuery, List<EmployeeResponse>>
{
    private readonly IEmployeeRepository _repository;

    public GetAllEmployeesHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<EmployeeResponse>> Handle(
        GetAllEmployeesQuery request,
        CancellationToken cancellationToken)
    {
        var employees = await _repository.GetAllAsync(cancellationToken);

        return employees.Select(e => new EmployeeResponse(
            e.Id,
            e.FirstName,
            e.LastName,
            e.Email,
            e.Document,
            e.Role,
            e.ManagerId,
            e.Phones.Select(p => p.Number).ToList()
        )).ToList();
    }
}
