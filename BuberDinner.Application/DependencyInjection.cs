using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Behaviors;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuberDinner.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //service.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
            //service.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            //services.AddScoped<IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>, ValidationBehavior>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
