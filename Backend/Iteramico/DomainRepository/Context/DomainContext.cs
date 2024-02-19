using DomainRepository.Configuration;
using DomainRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace DomainRepository.Context
{
    internal class DomainContext(DbContextOptions<DomainContext> options) : DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserConfiguration().Configure(modelBuilder.Entity<User>());
            new JourneyConfiguration().Configure(modelBuilder.Entity<Journey>());
            new ParticipationConfiguration().Configure(modelBuilder.Entity<JourneyParticipation>());
            new CityConfiguration().Configure(modelBuilder.Entity<City>());
            new CountryConfiguration().Configure(modelBuilder.Entity<Country>());
            new EventConfiguration().Configure(modelBuilder.Entity<Event>());
            new ExpenseParticipationConfiguration().Configure(modelBuilder.Entity<ExpenseParticipation>());
            new ReminderConfiguration().Configure(modelBuilder.Entity<Reminder>());
        }
    }
}