using MessageHub.Domain.Users;
using MessageHub.Infrastructure.Persistence.Context;

namespace MessageHub.Infrastructure.Persistence.Repositories.Users;

public sealed class UserRepository(MessageHubDbContext dbContext) : IUserRepository
{
    private readonly MessageHubDbContext _dbContext = dbContext;

    public async Task Create(User user)
    {
        _dbContext.Add(user);

        await _dbContext.SaveChangesAsync();
    }

    public Task<int> Delete(UserId id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetById(UserId id)
    {
        throw new NotImplementedException();
    }

    public Task<int> Update(User entity)
    {
        throw new NotImplementedException();
    }
}
