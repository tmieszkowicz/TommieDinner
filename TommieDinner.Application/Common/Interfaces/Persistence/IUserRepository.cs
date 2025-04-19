using TommieDinner.Domain.UserAggregate;

namespace TommieDinner.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void AddUser(User user);
}