namespace Domain.Interfaces;

public interface IEmployeeRepository
{
    Task CreateAsync(Employee employee, CancellationToken cancellationToken);
    Task<List<Employee>> GetAllAsync(CancellationToken cancellationToken);
    Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task UpdateAsync(Employee employee, CancellationToken cancellationToken);
    Task DeleteAsync(Employee employee, CancellationToken cancellationToken);    
    Task<Employee?> GetByEmailAsync(string email, CancellationToken cancellationToken);

}
