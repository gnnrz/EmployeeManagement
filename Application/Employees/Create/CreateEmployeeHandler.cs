using MediatR;
using CSharpFunctionalExtensions;
using Domain.Interfaces;
using Application.Common.Interfaces;
using Domain.Entities;

namespace Application.Employees.Create;

public class CreateEmployeeHandler
    : IRequestHandler<CreateEmployeeCommand, Result<Guid>>
{
    private readonly IEmployeeRepository _repository;
    private readonly ICurrentUser _currentUser;

    public CreateEmployeeHandler(
        IEmployeeRepository repository,
        ICurrentUser currentUser)
    {
        _repository = repository;
        _currentUser = currentUser;
    }

    public async Task<Result<Guid>> Handle(
        CreateEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        EmployeeRules.ValidateRoleHierarchy(
            _currentUser.Role,
            request.Role
        );

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var employee = Employee.Create(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Document,
            request.BirthDate,
            request.Role,
            request.ManagerId,
            request.Phones,
            passwordHash
        );

        await _repository.CreateAsync(employee, cancellationToken);

        return Result.Success(employee.Id);
    }
}
