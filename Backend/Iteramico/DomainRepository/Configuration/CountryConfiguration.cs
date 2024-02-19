using DomainRepository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainRepository.Configuration
{
    internal class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.LocalName).HasMaxLength(256);
            builder.Property(c => c.Name).HasMaxLength(256);
            builder.Property(c => c.CountryCode).HasMaxLength(3);
        }
    }
}