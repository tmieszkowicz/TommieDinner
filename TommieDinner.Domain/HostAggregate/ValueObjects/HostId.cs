using TommieDinner.Domain.Common.Models;

namespace TommieDinner.Domain.HostAggregate.ValueObjects;

public sealed class HostId : ValueObject
{
    public Guid Value { get; }

    private HostId(Guid value)
    {
        Value = value;
    }

    public static HostId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static HostId Create(Guid value)
    {
        return new HostId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static HostId CreateUnique(string hostId)
    {
        Guid.TryParse(hostId, out var guid);

        return new HostId(guid);
    }
}
