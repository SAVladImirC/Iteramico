using DomainRepository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainRepository.Configuration
{
    internal class TravelBuddyConfiguration : IEntityTypeConfiguration<TravelBuddy>
    {
        public void Configure(EntityTypeBuilder<TravelBuddy> builder)
        {
            builder.HasKey(tb => new { tb.User1Id, tb.User2Id });

            builder.HasOne(tb => tb.User1)
                .WithMany(u => u.TravelBuddies)
                .HasForeignKey(tb => tb.User1Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(tb => tb.User2)
                .WithMany(u => u.BuddiesOf)
                .HasForeignKey(tb => tb.User2Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}