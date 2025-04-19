using TommieDinner.Domain.BillAggregate.ValueObjects;
using TommieDinner.Domain.Common.Enums;
using TommieDinner.Domain.Common.Models;
using TommieDinner.Domain.Common.ValueObjects;
using TommieDinner.Domain.DinnerAggregate.Entities;
using TommieDinner.Domain.DinnerAggregate.ValueObjects;
using TommieDinner.Domain.HostAggregate.ValueObjects;
using TommieDinner.Domain.MenuAggregate.ValueObjects;

namespace TommieDinner.Domain.DinnerAggregate;

public sealed class Dinner : AggregateRoot<DinnerId>
{
    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }
    public DateTime? StartedDateTime { get; private set; }
    public DateTime? EndedDateTime { get; private set; }
    public DinnerStatus Status { get; private set; }
    public bool IsPublic { get; private set; }
    public int MaxGuests { get; private set; }
    public Price Price { get; private set; }
    public HostId HostId { get; private set; }
    public MenuId MenuId { get; private set; }
    public Uri ImageUrl { get; private set; }
    public Location Location { get; private set; }
    private readonly List<Reservation> _reservations = new();
    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public Dinner(
        DinnerId dinnerId,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DinnerStatus status,
        bool isPublic,
        int maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        Uri imageUrl,
        Location location) : base(dinnerId)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Status = status;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        ImageUrl = imageUrl;
        Location = location;
    }
    public static Dinner CreateUnique(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DinnerStatus status,
        bool isPublic,
        int maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        Uri imageUrl,
        Location location)
    {
        return new(
            DinnerId.CreateUnique(),
            name,
            description,
            startDateTime,
            endDateTime,
            status,
            isPublic,
            maxGuests,
            price,
            hostId,
            menuId,
            imageUrl,
            location);
    }
}