using MessageHub.Domain.Common;

namespace MessageHub.Infrastructure.Persistence.Repositories.Base;

public interface IWriteRepository<TEntity, TId> where TEntity : IAggregateRoot
{
    /// <summary>
    /// Create a <typeparamref name="TEntity"/>
    /// </summary>
    /// <param name="t">The <typeparamref name="TEntity"/> to create</param>
    Task Create(TEntity entity);

    /// <summary>
    /// Modify a <typeparamref name="TEntity"/>
    /// </summary>
    /// <param name="t">The <typeparamref name="TEntity"/> to modify</param>
    /// <returns>The number of <typeparamref name="TEntity"/> modified</returns>
    Task<int> Update(TEntity entity);

    /// <summary>
    /// Delete a <typeparamref name="TEntity"/>
    /// </summary>
    /// <param name="t">The <typeparamref name="TEntity"/> id to delete</param>
    /// <returns>The number of <typeparamref name="TEntity"/> deleted</returns>
    Task<int> Delete(TId id);
}
