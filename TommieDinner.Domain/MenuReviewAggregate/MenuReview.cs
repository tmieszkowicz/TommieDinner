namespace TommieDinner.Domain.MenuReview;

using TommieDinner.Domain.Common.Models;
using TommieDinner.Domain.DinnerAggregate.ValueObjects;
using TommieDinner.Domain.GuestAggregate.Entities;
using TommieDinner.Domain.GuestAggregate.ValueObjects;
using TommieDinner.Domain.HostAggregate.ValueObjects;
using TommieDinner.Domain.MenuAggregate.ValueObjects;
using TommieDinner.Domain.MenuReviewAggregate.ValueObjects;

public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
    public GuestRating Rating { get; }

    public string Comment { get; }

    public HostId HostId { get; }

    public MenuId MenuId { get; }
    public GuestId GuestId { get; }
    public DinnerId DinnerId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public MenuReview(
        MenuReviewId id,
        GuestRating guestRating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        Rating = guestRating;
        Comment = comment;
        HostId = hostId;
        MenuId = menuId;
        GuestId = guestId;
        DinnerId = dinnerId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static MenuReview CreateUnique(
        GuestRating guestRating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId)
    {
        return new(
            MenuReviewId.CreateUnique(),
            guestRating,
            comment,
            hostId,
            menuId,
            guestId,
            dinnerId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}