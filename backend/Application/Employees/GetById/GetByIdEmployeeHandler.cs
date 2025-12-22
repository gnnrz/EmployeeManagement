using Application.Employees.GetById;
using Domain.Interfaces;
using MediatR;

public class GetByIdEmployeeHandler
    : IRequestHandler<GetByIdEmployeeQuery, EmployeeResponse?>
{
    private readonly IEmployeeRepository _repository;

    public GetByIdEmployeeHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<EmployeeResponse?> Handle(
        GetByIdEmployeeQuery request,
        CancellationToken cancellationToken)
    {
        var employee = await _repository.GetByIdAsync(
            request.Id,
            cancellationToken
        );

        if (employee is null)
            return null;

        return new EmployeeResponse(
            employee.Id,
            employee.FirstName,
            employee.LastName,
            employee.Email,
            employee.Document,
            employee.Role,
            employee.ManagerId,
            employee.Phones.Select(p => p.Number).ToList()
        );
    }
}
