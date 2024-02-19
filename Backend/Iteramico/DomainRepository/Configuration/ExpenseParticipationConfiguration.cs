using DomainRepository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainRepository.Configuration
{
    internal class ExpenseParticipationConfiguration : IEntityTypeConfiguration<ExpenseParticipation>
    {
        public void Configure(EntityTypeBuilder<ExpenseParticipation> builder)
        {
            builder.HasKey(ep => new { ep.UserId, ep.ExpenseId });

            builder
                .HasOne(ep => ep.User)
                .WithMany(u => u.Expenses)
                .HasForeignKey(ep => ep.UserId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(ep => ep.Payer)
                .WithMany(u => u.Pays)
                .HasForeignKey(ep => ep.PayerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(ep => ep.Expense)
                .WithMany(j => j.Participations)
                .HasForeignKey(ep => ep.ExpenseId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}