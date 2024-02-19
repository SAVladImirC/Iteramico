using DomainRepository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainRepository.Configuration
{
    internal class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id);

            builder
                .HasOne(e => e.Creator)
                .WithMany();

            builder
                .HasOne(e => e.Journey)
                .WithMany();

            builder.Property(p => p.Name).HasMaxLength(100);
        }
    }
}