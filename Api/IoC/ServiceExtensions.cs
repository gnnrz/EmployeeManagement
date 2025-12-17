using Application.Common.Interfaces;
using Domain.Interfaces;
using Infrastructure.Auth;
using Infrastructure.Repositories;

namespace Api.IoC;

public static class ServiceExtensions
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IEmployeeRepository, InMemoryEmployeeRepository>();
        services.AddScoped<ICurrentUser, FakeCurrentUser>();
    }
}
