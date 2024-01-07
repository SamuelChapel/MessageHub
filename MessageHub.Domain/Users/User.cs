using MessageHub.Domain.Common;

namespace MessageHub.Domain.Users;

public sealed class User : Entity<UserId>, IAggregateRoot
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }

    public User(string firstName, string lastName, string email)
        : base(UserId.CreateUnique())
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
}
