using Microsoft.Extensions.DependencyInjection;
using UserManagementService.Services.Implementations;
using UserManagementService.Services.Interfaces;

namespace DomainService
{
    public static class Extensions
    {
        public static IServiceCollection RegisterDomainServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}