namespace MessageHub.Api.Contracts.Users;

public record CreateUserRequest(
    string FirstName,
    string LastName,
    string Email
    );
