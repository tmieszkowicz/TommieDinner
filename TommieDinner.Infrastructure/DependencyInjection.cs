using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TommieDinner.Application.Common.Interfaces.Persistence;
using TommieDinner.Application.Common.Interfaces.Services;
using TommieDinner.Application.Services.Authentication;
using TommieDinner.Infrastructure.Authentication;
using TommieDinner.Infrastructure.Persistence;
using TommieDinner.Infrastructure.Persistence.Interceptors;
using TommieDinner.Infrastructure.Persistence.Repositories;
using TommieDinner.Infrastructure.Services;

namespace TommieDinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services
            .AddAuth(configuration)
            .AddPersistence();

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
    public static IServiceCollection AddPersistence(
    this IServiceCollection services)
    {
        services.AddDbContext<TommieDinnerDbContext>(options =>
            options.UseSqlServer("Server=localhost,1434;Database=TommieDinner;User Id=sa;Password=Admin123!;trustServerCertificate=true"));

        services.AddScoped<PublishDomainEventsInterceptor>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();

        return services;
    }
    public static IServiceCollection AddAuth(
    this IServiceCollection services,
    ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IWJtwTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
            });

        return services;
    }
}