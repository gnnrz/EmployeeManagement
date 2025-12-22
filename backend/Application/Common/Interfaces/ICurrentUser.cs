using Domain.Enums;

namespace Application.Common.Interfaces;

public interface ICurrentUser
{
    Role Role { get; }
}
