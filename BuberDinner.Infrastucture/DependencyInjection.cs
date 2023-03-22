using BuberDinner.Application.Common.Authentication;
using BuberDinner.Application.Common.Services;
using BuberDinner.Infrastucture.Authentication;
using Microsoft.Extensions.DependencyInjection;
using BuberDinner.Infrastucture.Services;

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
            return service;
        }
    }
}
