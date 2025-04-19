using ErrorOr;
using MediatR;
using TommieDinner.Application.Authentication.Common;

namespace TommieDinner.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;