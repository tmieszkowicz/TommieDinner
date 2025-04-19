using TommieDinner.Domain.Common.Models;

namespace TommieDinner.Domain.MenuAggregate.Events;

public record MenuCreated(Menu Menu) : IDomainEvent;