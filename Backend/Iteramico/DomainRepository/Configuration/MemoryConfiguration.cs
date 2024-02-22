using DomainRepository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainRepository.Configuration
{
    internal class MemoryConfiguration : IEntityTypeConfiguration<Memory>
    {
        public void Configure(EntityTypeBuilder<Memory> builder)
        {
            builder.HasKey(m => m.Id);

            builder
                .HasOne(m => m.Creator)
                .WithMany();

            builder
                .HasOne(m => m.Journey)
                .WithMany(j => j.Memories);

            builder.Property(m => m.Name).HasMaxLength(100);
            builder.Property(m => m.ImagePath).HasMaxLength(100);
        }
    }
}