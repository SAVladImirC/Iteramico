using DomainRepository.Context;
using DomainRepository.Repositories.Implementations;
using DomainRepository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DomainRepository
{
    public static class Extensions
    {
        public static IServiceCollection RegisterDomainDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DomainContext>(c =>
            {
                c.UseSqlServer(configuration.GetConnectionString("Iteramico"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure();
                    });
                c.UseLazyLoadingProxies();
                c.EnableDetailedErrors();
                c.EnableSensitiveDataLogging();
            });
            return services;
        }

        public static IServiceCollection RegisterDomainRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IJourneyRepository, JourneyRepository>();
            services.AddTransient<IReminderRepository, ReminderRepository>();
            services.AddTransient<IMemoryRepository, MemoryRepository>();
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<IJourneyParticipationRepository, JourneyParticipationRepository>();
            services.AddTransient<IExpenseRepository, ExpenseRepository>();

            return services;
        }
    }
}