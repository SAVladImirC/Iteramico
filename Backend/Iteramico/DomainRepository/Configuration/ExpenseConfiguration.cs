using DomainRepository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainRepository.Configuration
{
    internal class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(e => e.Id);

            builder
                .HasOne(e => e.Creator)
                .WithMany();

            builder
                .HasOne(e => e.Journey)
                .WithMany(j => j.Expenses);

            builder.Property(p => p.Description).HasMaxLength(100);
            builder.Property(p => p.Currency).HasMaxLength(3);
        }
    }
}