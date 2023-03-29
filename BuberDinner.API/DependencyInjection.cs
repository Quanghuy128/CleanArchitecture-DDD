using BuberDinner.API.Common.Errors;
using BuberDinner.API.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BuberDinner.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, BuberDinnnerProblemDetailFactory>();
            services.AddMappings();
            return services;
        }
    }
}
