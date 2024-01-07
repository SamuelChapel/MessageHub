using MessageHub.Application.Common;
using MessageHub.Domain.Users;
using MessageHub.Infrastructure.Persistence.Repositories.Users;

namespace MessageHub.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler(IUserRepository userRepository) : ICommandHandler<CreateUserCommand, User>
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<User> Handle(CreateUserCommand command)
    {
        var user = new User(
            command.FirstName,
            command.LastName,
            command.Email);

        await _userRepository.Create(user);

        return user;
    }
}
