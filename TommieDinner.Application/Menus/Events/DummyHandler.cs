using MediatR;
using TommieDinner.Domain.MenuAggregate.Events;

namespace TommieDinner.Application.Menus.Events;

public class DummyHandler : INotificationHandler<MenuCreated>
{
    public Task Handle(MenuCreated notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}