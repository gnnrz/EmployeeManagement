namespace Domain.Interfaces;

public interface IEmployeeRepository
{
    Task CreateAsync(Employee employee, CancellationToken cancellationToken);
    Task<IEnumerable<Employee>> GetAllAsync(CancellationToken cancellationToken);
    Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task UpdateAsync(Employee employee, CancellationToken cancellationToken);
    Task DeleteAsync(Employee employee, CancellationToken cancellationToken);
}
