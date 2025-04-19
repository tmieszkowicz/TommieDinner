using TommieDinner.Domain.Common.Models;
using TommieDinner.Domain.Common.ValueObjects;
using TommieDinner.Domain.DinnerAggregate.ValueObjects;
using TommieDinner.Domain.HostAggregate.ValueObjects;
using TommieDinner.Domain.MenuAggregate.ValueObjects;
using TommieDinner.Domain.UserAggregate.ValueObjects;

namespace TommieDinner.Domain.Host;

public sealed class Host : AggregateRoot<HostId>
{
    public string FirstName { get; }
    public string LastName { get; }
    public Uri ProfilePicture { get; }
    AverageRating? AverageRating { get; }
    public UserId UserId { get; }

    private readonly List<MenuId> _menus = new();
    public IReadOnlyList<MenuId> Menus => _menus.AsReadOnly();
    private readonly List<DinnerId> _dinnerIds = new();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public Host(
        HostId hostId,
        string firstName,
        string lastName,
        Uri profilePicture,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(hostId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfilePicture = profilePicture;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
    public static Host CreateUnique(
        string firstName,
        string lastName,
        Uri profilePicture,
        UserId userId)
    {
        return new(
            HostId.CreateUnique(),
            firstName,
            lastName,
            profilePicture,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}