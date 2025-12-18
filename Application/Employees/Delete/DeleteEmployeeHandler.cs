using Domain.Interfaces;
using MediatR;

namespace Application.Employees.Delete;

public class DeleteEmployeeHandler
    : IRequestHandler<DeleteEmployeeCommand, bool>
{
    private readonly IEmployeeRepository _repository;

    public DeleteEmployeeHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        DeleteEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        var employee = await _repository.GetByIdAsync(
            request.Id,
            cancellationToken
        );

        if (employee is null)
            return false;

        await _repository.DeleteAsync(employee, cancellationToken);
        return true;
    }
}
