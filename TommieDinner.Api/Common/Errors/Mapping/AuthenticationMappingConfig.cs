using Mapster;
using TommieDinner.Application.Authentication.Commands.Register;
using TommieDinner.Application.Authentication.Common;
using TommieDinner.Application.Authentication.Queries.Login;
using TommieDinner.Contracts.Authentication;

namespace TommieDinner.Api.Common.Errors.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}