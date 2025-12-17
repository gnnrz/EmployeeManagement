using Application.Common.Interfaces;
using Domain.Enums;

namespace Infrastructure.Auth;

public class FakeCurrentUser : ICurrentUser
{
    public Role Role => Role.Director; // pode criar qualquer um
}
