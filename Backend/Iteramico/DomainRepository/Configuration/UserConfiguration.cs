using DomainRepository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainRepository.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder
                .OwnsOne(u => u.Auth, a => a.ToTable("Auth"));

            builder.Property(u => u.Email).HasMaxLength(128);
            builder.Property(u => u.FirstName).HasMaxLength(70).HasDefaultValue("");
            builder.Property(u => u.LastName).HasMaxLength(70).HasDefaultValue("");
            builder.Property(u => u.PhoneNumber).HasMaxLength(30).HasDefaultValue("");
            builder.Property(u => u.Gender).HasMaxLength(1);
        }
    }
}