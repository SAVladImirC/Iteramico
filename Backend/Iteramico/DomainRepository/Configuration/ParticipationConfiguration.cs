using DomainRepository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainRepository.Configuration
{
    internal class ParticipationConfiguration : IEntityTypeConfiguration<JourneyParticipation>
    {
        public void Configure(EntityTypeBuilder<JourneyParticipation> builder)
        {
            builder.HasKey(p => new { p.UserId, p.JourneyId });

            builder
                .HasOne(p => p.User)
                .WithMany(u => u.Participations);

            builder
                .HasOne(p => p.Journey)
                .WithMany(j => j.Participations);
        }
    }
}