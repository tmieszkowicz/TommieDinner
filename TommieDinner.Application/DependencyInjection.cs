using Microsoft.Extensions.DependencyInjection;
using MediatR;
using TommieDinner.Application.Authentication.Commands.Register;
using ErrorOr;
using TommieDinner.Application.Authentication.Common;
using FluentValidation;
using System.Reflection;
using TommieDinner.Application.Authentication.Common.Behaviors;

namespace TommieDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly); });

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}