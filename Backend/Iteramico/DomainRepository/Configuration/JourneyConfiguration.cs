using DomainRepository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainRepository.Configuration
{
    internal class JourneyConfiguration : IEntityTypeConfiguration<Journey>
    {
        public void Configure(EntityTypeBuilder<Journey> builder)
        {
            builder.HasKey(j => j.Id);

            builder
                .HasOne(j => j.Creator)
                .WithMany()
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(j => j.To)
                .WithMany()
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(j => j.Name).HasMaxLength(256);
        }
    }
}