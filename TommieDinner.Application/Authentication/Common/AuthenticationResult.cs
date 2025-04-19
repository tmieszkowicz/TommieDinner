using TommieDinner.Domain.UserAggregate;

namespace TommieDinner.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);