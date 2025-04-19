using ErrorOr;
using MediatR;
using TommieDinner.Application.Authentication.Common;
using TommieDinner.Application.Common.Interfaces.Persistence;
using TommieDinner.Application.Services.Authentication;
using TommieDinner.Domain.Common.Errors;
using TommieDinner.Domain.UserAggregate;

namespace TommieDinner.Application.Authentication.Commands.Register;

public class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IWJtwTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IWJtwTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }


    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        var user = User.CreateUnique(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Password);

        // var user = new User
        // {
        //     FirstName = command.FirstName,
        //     LastName = command.LastName,
        //     Email = command.Email,
        //     Password = command.Password
        // };

        _userRepository.AddUser(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}