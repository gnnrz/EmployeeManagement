namespace Domain.Entities;

public class Phone
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Number { get; private set; }

    private Phone() { }

    public Phone(string number)
    {
        if (string.IsNullOrWhiteSpace(number))
            throw new ArgumentException("Phone number is required.");

        Number = number;
    }
}
