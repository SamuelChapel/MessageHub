using MessageHub.Domain.Common;

namespace MessageHub.Domain.Users;

public sealed class UserId(Guid value) : EntityId<Guid>(value)
{
    public static UserId CreateUnique()
    {
        return new UserId(Guid.NewGuid());
    }
}
