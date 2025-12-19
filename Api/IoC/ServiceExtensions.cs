using Application.Common.Interfaces;
using Infrastructure.Auth;

namespace Api.IoC;

public static class ServiceExtensions
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICurrentUser, FakeCurrentUser>();
    }
}
