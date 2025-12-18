using Application.Common.Interfaces;
using Domain.Interfaces;
using MediatR;

namespace Application.Employees.Update;

public class UpdateEmployeeHandler
    : IRequestHandler<UpdateEmployeeCommand, bool>
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

    public async Task<bool> Handle(
        UpdateEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        var employee = await _repository.GetByIdAsync(
            request.Id,
            cancellationToken
        );

        if (employee is null)
            return false;

        EmployeeRules.ValidateRoleHierarchy(
            _currentUser.Role,
            request.Role
        );

        employee.Update(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Document,
            request.BirthDate,
            request.Role,
            request.ManagerId,
            request.Phones
        );

        await _repository.UpdateAsync(employee, cancellationToken);
        return true;
    }
}
