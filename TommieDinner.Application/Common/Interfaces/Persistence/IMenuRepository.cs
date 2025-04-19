using TommieDinner.Domain.MenuAggregate;

namespace TommieDinner.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    void Add(Menu menu);
}