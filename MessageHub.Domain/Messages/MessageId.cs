using MessageHub.Domain.Common;
using MessageHub.Domain.Users;

namespace MessageHub.Domain.Messages;

public sealed class MessageId(Guid value) : EntityId<Guid>(value)
{
	public static UserId CreateUnique()
	{
		return new UserId(Guid.NewGuid());
	}
}