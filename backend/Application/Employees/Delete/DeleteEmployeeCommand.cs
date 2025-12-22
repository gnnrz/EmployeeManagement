using CSharpFunctionalExtensions;
using MediatR;

namespace Application.Employees.Delete;

public record DeleteEmployeeCommand(Guid Id)
    : IRequest<Result>;