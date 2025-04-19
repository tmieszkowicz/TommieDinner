using Microsoft.EntityFrameworkCore;
using TommieDinner.Domain.Common.Models;
using TommieDinner.Domain.MenuAggregate;
using TommieDinner.Infrastructure.Persistence.Interceptors;

namespace TommieDinner.Infrastructure.Persistence;

public class TommieDinnerDbContext : DbContext
{
    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;
    public TommieDinnerDbContext(DbContextOptions<TommieDinnerDbContext> options, PublishDomainEventsInterceptor publishDomainEventsInterceptor) : base(options)
    {
        _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
    }
    public DbSet<Menu> Menus { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(TommieDinnerDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}