using CSharpFunctionalExtensions;
using MediatR;

namespace Application.Auth.Login;

public record LoginCommand(
    string Email,
    string Password
) : IRequest<Result<LoginResponse>>;
