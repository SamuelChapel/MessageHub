using MessageHub.Domain.Common;
using MessageHub.Domain.Messages;

namespace MessageHub.Domain.Users;

public sealed class User : Entity<UserId>, IAggregateRoot
{
    private readonly List<Message> _messages = [];
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public IReadOnlyList<Message> Messages => _messages.AsReadOnly();

    public User(string firstName, string lastName, string email)
        : base(UserId.CreateUnique())
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public void AddMessage(Message message)
    {
        _messages.Add(message);
    }
}
