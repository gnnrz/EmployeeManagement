using Application.Common.Interfaces;
using CSharpFunctionalExtensions;
using Domain.Interfaces;
using MediatR;

namespace Application.Auth.Login;

public class LoginHandler
    : IRequestHandler<LoginCommand, Result<LoginResponse>>
{
    private readonly IEmployeeRepository _repository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenService _tokenService;

    public LoginHandler(
        IEmployeeRepository repository,
        IPasswordHasher passwordHasher,
        ITokenService tokenService)
    {
        _repository = repository;
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
    }

    public async Task<Result<LoginResponse>> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {
        var employee = await _repository.GetByEmailAsync(
            request.Email,
            cancellationToken
        );

        if (employee is null)
            return Result.Failure<LoginResponse>("Invalid credentials");

        if (!_passwordHasher.Verify(request.Password, employee.PasswordHash))
            return Result.Failure<LoginResponse>("Invalid credentials");

        var token = _tokenService.Generate(employee);

        return Result.Success(new LoginResponse(
            token,
            3600
        ));
    }
}
