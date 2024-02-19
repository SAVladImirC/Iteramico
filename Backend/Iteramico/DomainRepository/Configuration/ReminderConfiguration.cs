using DomainRepository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainRepository.Configuration
{
    internal class ReminderConfiguration : IEntityTypeConfiguration<Reminder>
    {
        public void Configure(EntityTypeBuilder<Reminder> builder)
        {
            builder.HasKey(r => r.Id);

            builder
                .HasOne(r => r.Creator)
                .WithMany()
                .HasForeignKey(r => r.CreatorId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasOne(r => r.Journey)
                .WithMany()
                .HasForeignKey(r => r.JourneyId);

            builder
                .HasOne(r => r.For)
                .WithMany(u => u.Reminders)
                .HasForeignKey(r => r.ForId);

            builder.Property(p => p.Note).HasMaxLength(100);
        }
    }
}