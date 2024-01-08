using MessageHub.Domain.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MessageHub.Infrastructure.Persistence.Configurations;

public class MessageConfigurations : IEntityTypeConfiguration<Message>
{
	public void Configure(EntityTypeBuilder<Message> builder)
	{
		builder.ToTable("Message");

		builder.HasKey(m => m.Id);
		
		builder.Property(m => m.Id)
		       .ValueGeneratedNever()
		       .HasConversion(
		                      userId => userId.Value,
		                      value => new MessageId(value)
		                     );

		builder.Property(m => m.Emitter)
		       .IsRequired();

		builder.Property(m => m.Content)
		       .IsRequired();

		builder.Property(m => m.Date)
		       .IsRequired();

		builder.HasOne(m => m.User)
		       .WithMany(u => u.Messages)
		       .HasForeignKey(u => u.UserId)
		       .IsRequired();
	}
}