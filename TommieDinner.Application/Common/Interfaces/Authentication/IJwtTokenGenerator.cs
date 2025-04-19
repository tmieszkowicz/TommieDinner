using TommieDinner.Domain.UserAggregate;

namespace TommieDinner.Application.Services.Authentication;

public interface IWJtwTokenGenerator
{
    string GenerateToken(User user);
}