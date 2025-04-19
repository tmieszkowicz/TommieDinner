using Mapster;
using TommieDinner.Domain.UserAggregate;

namespace TommieDinner.Api.Common.Errors.Mapping;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<User, User>()
            .ConstructUsing(src => User.CreateUnique(src.FirstName, src.LastName, src.Email, src.Password));
    }
}
