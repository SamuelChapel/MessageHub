using MessageHub.Domain.Common;
using MessageHub.Domain.Users;

namespace MessageHub.Domain.Messages;

public sealed class Message: Entity<MessageId>, IAggregateRoot
{
	public string Emitter { get; private set; }
	public string Content { get; private set; }
	public DateOnly Date { get; private set; }
	public UserId UserId { get; private set; } 
	public User User { get; private set; } 

	public Message(MessageId id, string emitter, string content, DateOnly date, UserId userId)
		: base(id)
	{
		Emitter = emitter;
		Content = content;
		Date = date;
		UserId = userId;
	}
}