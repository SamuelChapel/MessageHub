using MessageHub.Domain.Users;
using MessageHub.Infrastructure.Persistence.Repositories.Base;

namespace MessageHub.Infrastructure.Persistence.Repositories.Users;

public interface IUserRepository : IReadRepository<User, UserId>, IWriteRepository<User, UserId>
{
}
