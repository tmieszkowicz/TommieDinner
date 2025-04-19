using TommieDinner.Domain.Common.Models;

namespace TommieDinner.Domain.GuestAggregate.ValueObjects;

public sealed class GuestRatingId : ValueObject
{
    public Guid Value { get; }

    private GuestRatingId(Guid value)
    {
        Value = value;
    }

    public static GuestRatingId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}