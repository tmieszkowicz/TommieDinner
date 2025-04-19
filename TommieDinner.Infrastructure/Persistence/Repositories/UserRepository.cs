using TommieDinner.Application.Common.Interfaces.Persistence;
using TommieDinner.Domain.UserAggregate;

namespace TommieDinner.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();
    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }
}