using Contact.Domain.AggregatesModel.ContactAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contact.Infrastructure.EntityConfigrations
{
    public class ContactInformationEntityTypeConfigration : IEntityTypeConfiguration<ContactInformation>
    {
        public void Configure(EntityTypeBuilder<ContactInformation> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.PhoneNumber)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(b => b.EmailAddress)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(b => b.Location)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(b => b.Content)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne<ContactItem>()
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey("ContactId");
        }
    }
}
