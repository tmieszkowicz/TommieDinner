using ErrorOr;
using MediatR;
using TommieDinner.Application.Authentication.Common;

namespace TommieDinner.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;