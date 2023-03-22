using BuberDinner.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            service.AddScoped<IAuthenticationService, AuthenticationService>();
            return service;
        }
    }
}
