using MessageHub.Domain.Common;
using MessageHub.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace MessageHub.Infrastructure.Persistence.Context;

public sealed class MessageHubDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MessageHubDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=MSI; Initial Catalog=MessageHub; Integrated Security=SSPI; TrustServerCertificate=True");
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        ChangeTracker
            .Entries()
            .Where(e => e.Entity is DatableEntity && e.State is EntityState.Added or EntityState.Modified)
            .ToList()
            .ForEach(e =>
            {
                if (e.State is EntityState.Added)
                {
                    ((DatableEntity)e.Entity).SetCreatedAt();
                }

                ((DatableEntity)e.Entity).ModifyUpdatedAt();
            });

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}
