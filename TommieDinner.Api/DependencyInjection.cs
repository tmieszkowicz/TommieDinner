using Microsoft.AspNetCore.Mvc.Infrastructure;
using TommieDinner.Api.Common.Errors;
using TommieDinner.Api.Common.Errors.Mapping;

namespace TommieDinner.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddSingleton<ProblemDetailsFactory, TommieDinnerProblemDetailsFactory>();

        services.AddMappings();

        return services;
    }
}