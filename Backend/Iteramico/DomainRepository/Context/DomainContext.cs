using DomainRepository.Configuration;
using DomainRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace DomainRepository.Context
{
    internal class DomainContext(DbContextOptions<DomainContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<JourneyParticipation> JourneyParticipations { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<ExpenseParticipation> ExpenseParticipations { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Memory> Memories { get; set; }

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
            new ExpenseConfiguration().Configure(modelBuilder.Entity<Expense>());
            new MemoryConfiguration().Configure(modelBuilder.Entity<Memory>());
        }
    }
}