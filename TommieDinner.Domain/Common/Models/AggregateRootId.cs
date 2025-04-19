namespace TommieDinner.Domain.Common.Models;

public abstract class AggregateRoot<TId> : ValueObject
{
    public abstract TId Value { get; protected set; }
}