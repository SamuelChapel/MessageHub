using MessageHub.Domain.Messages;
using MessageHub.Domain.Users;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MessageHub.Infrastructure.Persistence.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedNever()
            .HasConversion(
                userId => userId.Value,
                value => new UserId(value)
            );

        builder.Property(u => u.FirstName)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(u => u.LastName)
               .HasMaxLength(100)
               .IsRequired();

        builder.HasMany(u => u.Messages)
               .WithOne(m => m.User)
               .HasForeignKey(m => m.UserId)
               .IsRequired();

        builder.Navigation(u => u.Messages)
               .UsePropertyAccessMode(PropertyAccessMode.Property);
    }
}
