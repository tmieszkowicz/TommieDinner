using TommieDinner.Application.Common.Interfaces.Persistence;
using TommieDinner.Domain.MenuAggregate;

namespace TommieDinner.Infrastructure.Persistence.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly TommieDinnerDbContext _dbContext;

    public MenuRepository(TommieDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Menu menu)
    {
        _dbContext.Add(menu);

        _dbContext.SaveChanges();
    }
}