using TommieDinner.Domain.Common.Models;
using TommieDinner.Domain.Common.ValueObjects;
using TommieDinner.Domain.DinnerAggregate.ValueObjects;
using TommieDinner.Domain.GuestAggregate.Entities;
using TommieDinner.Domain.GuestAggregate.ValueObjects;
using TommieDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace TommieDinner.Domain.Guest;

public sealed class Guest : AggregateRoot<GuestId>
{
    public string FirstName { get; }
    public string LastName { get; }
    public Uri ProfilePicture { get; }
    AverageRating? AverageRating { get; }

    private readonly List<DinnerId> _upcomingDinnerIds = new();
    public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
    private readonly List<DinnerId> _pastDinnerIds = new();
    public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
    private readonly List<DinnerId> _pendingDinnerIds = new();
    public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();

    private readonly List<BillId> _billIds = new();
    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    private readonly List<GuestRating> _guestRatings = new();
    public IReadOnlyList<GuestRating> GuestRatings => _guestRatings.AsReadOnly();

    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public Guest(
        GuestId guestId,
        string firstName,
        string lastName,
        Uri profilePicture,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(guestId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfilePicture = profilePicture;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Guest CreateUnique(
        string firstName,
        string lastName,
        Uri profilePicture)
    {
        return new(
            GuestId.CreateUnique(),
            firstName,
            lastName,
            profilePicture,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}