namespace Application.Auth.Login;

public record LoginResponse(
    string AccessToken,
    int ExpiresIn
);
