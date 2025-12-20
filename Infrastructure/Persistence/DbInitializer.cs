using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence;

public static class DbInitializer
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        await context.Database.MigrateAsync();

        if (await context.Employees.AnyAsync())
            return;

        var admin = Employee.Create(
            firstName: "Master",
            lastName: "Admin",
            email: "admin@employee.com",
            document: "00000000000",
            birthDate: DateTime.Today.AddYears(-30),
            role: Role.Director,
            managerId: null,
            phones: new[]
            {
                new Phone("51999999999"),
                new Phone("51888888888")
            },
            passwordHash: BCrypt.Net.BCrypt.HashPassword("admin@123")
        );

        context.Employees.Add(admin);
        await context.SaveChangesAsync();
    }
}
