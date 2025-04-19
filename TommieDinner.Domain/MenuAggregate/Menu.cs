using TommieDinner.Domain.Common.Models;
using TommieDinner.Domain.Common.ValueObjects;
using TommieDinner.Domain.DinnerAggregate.ValueObjects;
using TommieDinner.Domain.HostAggregate.ValueObjects;
using TommieDinner.Domain.MenuAggregate.Entities;
using TommieDinner.Domain.MenuAggregate.Events;
using TommieDinner.Domain.MenuAggregate.ValueObjects;
using TommieDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace TommieDinner.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId, Guid>
{
    public string? Name { get; private set; }
    public string Description { get; private set; }
    public AverageRating? AverageRating { get; private set; }
    public HostId HostId { get; private set; }

    private readonly List<MenuSection> _menuSections = new();
    public IReadOnlyList<MenuSection> MenuSections => _menuSections.AsReadOnly();
    private readonly List<DinnerId> _dinnerIds = new();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    private readonly List<MenuReviewId> _menuReviewIds = new();

    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public Menu(
        MenuId id,
        HostId hostId,
        string name,
        string description,
        AverageRating averageRating,
        List<MenuSection> menuSections) : base(id)
    {
        HostId = hostId;
        Name = name;
        Description = description;
        AverageRating = averageRating;
        _menuSections = menuSections;
    }

    public static Menu CreateUnique(
        HostId hostId,
        string name,
        string description,
        List<MenuSection>? sections)
    {
        var menu = new Menu(
            MenuId.CreateUnique(),
            hostId,
            name,
            description,
            AverageRating.CreateNew(),
            sections ?? new());

        menu.AddDomainEvent(new MenuCreated(menu));

        return menu;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Menu() : base(MenuId.CreateUnique()) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
}