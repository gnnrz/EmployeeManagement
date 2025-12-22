using Application.Common.Interfaces;
using CSharpFunctionalExtensions;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Employees.Update;

public class UpdateEmployeeHandler
    : IRequestHandler<UpdateEmployeeCommand, Result>
{
    private readonly IEmployeeRepository _repository;
    private readonly ICurrentUser _currentUser;

    public UpdateEmployeeHandler(
        IEmployeeRepository repository,
        ICurrentUser currentUser)
    {
        _repository = repository;
        _currentUser = currentUser;
    }

    public async Task<Result> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        EmployeeRules.ValidateRoleHierarchy(
            _currentUser.Role,
            request.Role
        );

        var employee = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (employee is null)
            return Result.Failure("Employee not found");

        employee.UpdateBasicInfo(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Role,
            request.ManagerId
        );

        employee.ReplacePhones(
            request.Phones.Select(p => new Phone(p))
        );

        await _repository.UpdateAsync(employee, cancellationToken);

        return Result.Success();
    }
}
