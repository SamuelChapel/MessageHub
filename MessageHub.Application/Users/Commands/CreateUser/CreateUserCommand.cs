using MessageHub.Application.Common;

namespace MessageHub.Application.Users.Commands.CreateUser;

public record CreateUserCommand(
    string FirstName,
    string LastName,
    string Email
    ) : ICommand;
