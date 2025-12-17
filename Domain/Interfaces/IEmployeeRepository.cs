using Domain.Entities;

namespace Domain.Interfaces;

public interface IEmployeeRepository
{
    Task CreateAsync(Employee employee, CancellationToken cancellationToken);
    Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
