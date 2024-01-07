namespace MessageHub.Domain.Common;

public abstract class DatableEntity : ValueObject
{
    public DateTime CreatedAt { get; protected set; }
    public DateTime UpdatedAt { get; protected set; }

    public void SetCreatedAt(DateTime? when = null)
    {
        CreatedAt = when ?? DateTime.UtcNow;
    }

    public void ModifyUpdatedAt(DateTime? when = null)
    {
        UpdatedAt = when ?? DateTime.UtcNow;
    }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return CreatedAt;
        yield return UpdatedAt;
    }
}
