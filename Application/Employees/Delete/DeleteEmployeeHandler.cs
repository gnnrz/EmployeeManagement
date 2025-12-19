using CSharpFunctionalExtensions;
using Domain.Interfaces;
using MediatR;

namespace Application.Employees.Delete;

public class DeleteEmployeeHandler
    : IRequestHandler<DeleteEmployeeCommand, Result>
{
    private readonly IEmployeeRepository _repository;

    public DeleteEmployeeHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (employee is null)
            return Result.Failure("Employee not found");

        await _repository.DeleteAsync(employee, cancellationToken);

        return Result.Success();
    }
}
