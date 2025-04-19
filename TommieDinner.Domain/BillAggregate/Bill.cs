using TommieDinner.Domain.BillAggregate.ValueObjects;
using TommieDinner.Domain.Common.Models;
using TommieDinner.Domain.DinnerAggregate.ValueObjects;
using TommieDinner.Domain.GuestAggregate.ValueObjects;
using TommieDinner.Domain.HostAggregate.ValueObjects;

namespace TommieDinner.Domain.BillAggregate;

public class Bill : AggregateRoot<BillId>
{
    public GuestId GuestId { get; private set; }
    public HostId HostId { get; private set; }
    public Price Price { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public Bill(
        BillId billId,
        GuestId guestId,
        HostId hostId,
        Price price,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(billId)
    {
        GuestId = guestId;
        HostId = hostId;
        Price = price;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
    public static Bill CreateUnique(
        GuestId guestId,
        HostId hostId,
        Price price)
    {
        return new(
            BillId.CreateUnique(),
            guestId,
            hostId,
            price,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}