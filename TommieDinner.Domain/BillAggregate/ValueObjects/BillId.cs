using TommieDinner.Domain.Common.Models;

namespace TommieDinner.Domain.DinnerAggregate.ValueObjects;

public sealed class BillId : ValueObject
{
    public Guid Value { get; }

    private BillId(Guid value)
    {
        Value = value;
    }

    public static BillId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
