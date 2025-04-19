using ErrorOr;

namespace TommieDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Validation(
            code: "authentication.invalid_credentials",
            description: "Invalid credentials.");
    }
}