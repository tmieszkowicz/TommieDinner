using TommieDinner.Domain.Common.Models;
using TommieDinner.Domain.DinnerAggregate.ValueObjects;
using TommieDinner.Domain.GuestAggregate.ValueObjects;
using TommieDinner.Domain.HostAggregate.ValueObjects;

namespace TommieDinner.Domain.GuestAggregate.Entities;

public sealed class GuestRating : Entity<GuestRatingId>
{
    public double Rating { get; }
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public GuestRating(
        GuestRatingId guestRatingId,
        int rating,
        HostId hostId,
        DinnerId dinnerId,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(guestRatingId)
    {
        Rating = rating;
        HostId = hostId;
        DinnerId = dinnerId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static GuestRating CreateUnique(
        int rating,
        HostId hostId,
        DinnerId dinnerId)
    {
        return new(
            GuestRatingId.CreateUnique(),
            rating,
            hostId,
            dinnerId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}