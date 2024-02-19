using DomainRepository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainRepository.Configuration
{
    internal class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.LocalName).HasMaxLength(256);
            builder.Property(c => c.Name).HasMaxLength(256);
        }
    }
}