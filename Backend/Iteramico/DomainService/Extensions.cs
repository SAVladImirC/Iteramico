using DomainService.Services.Implementations;
using DomainService.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DomainService
{
    public static class Extensions
    {
        public static IServiceCollection RegisterDomainServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IMemoryService, MemoryService>();
            services.AddTransient<IReminderService, ReminderService>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IJourneyService, JourneyService>();
            services.AddTransient<IExpenseService, ExpenseService>();

            return services;
        }
    }
}