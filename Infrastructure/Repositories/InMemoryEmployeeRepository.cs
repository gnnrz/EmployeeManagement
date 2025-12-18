using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class InMemoryEmployeeRepository : IEmployeeRepository
{
    private static readonly List<Employee> _employees = new();

    public Task CreateAsync(Employee employee, CancellationToken cancellationToken)
    {
        _employees.Add(employee);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<Employee>> GetAllAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult(_employees.AsEnumerable());
    }

    public Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return Task.FromResult(_employees.FirstOrDefault(e => e.Id == id));
    }

    public Task UpdateAsync(Employee employee, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Employee employee, CancellationToken cancellationToken)
    {
        _employees.Remove(employee);
        return Task.CompletedTask;
    }
}
