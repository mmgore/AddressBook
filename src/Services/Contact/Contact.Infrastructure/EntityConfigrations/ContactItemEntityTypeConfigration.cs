using Contact.Domain.AggregatesModel.ContactAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contact.Infrastructure.EntityConfigrations
{
    public class ContactItemEntityTypeConfigration : IEntityTypeConfiguration<ContactItem>
    {
        public void Configure(EntityTypeBuilder<ContactItem> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(b => b.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(b => b.Firm)
                .HasMaxLength(60)
                .IsRequired();
        }
    }
}
