using Domain.Interfaces;
using MediatR;

namespace Application.Employees.GetById;

public class GetEmployeeByIdHandler
    : IRequestHandler<GetEmployeeByIdQuery, Employee?>
{
    private readonly IEmployeeRepository _repository;

    public GetEmployeeByIdHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Employee?> Handle(
        GetEmployeeByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(
            request.Id,
            cancellationToken
        );
    }
}
