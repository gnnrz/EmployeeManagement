namespace Domain.Entities;

public class Phone
{
    public Guid Id { get; private set; }
    public string Number { get; private set; } = null!;
    public Guid EmployeeId { get; private set; }

    private Phone() { }

    public Phone(string number)
    {
        Number = number;
    }
}
