using BuberDinner.Application.Common.Authentication;
using BuberDinner.Application.Common.Services;
using BuberDinner.Infrastucture.Authentication;
using Microsoft.Extensions.DependencyInjection;
using BuberDinner.Infrastucture.Services;
using BuberDinner.Application.Common.Persistence;
using BuberDinner.Infrastucture.Persistence;

namespace BuberDinner.Infrastucture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastucture(
            this IServiceCollection service,
            Microsoft.Extensions.Configuration.ConfigurationManager configuration
            )
        {
            service.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            service.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            service.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            service.AddScoped<IUserRepository, UserRepository>();
            return service;
        }
    }
}
