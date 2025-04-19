using TommieDinner.Domain.Common.Models;
using TommieDinner.Domain.Menu.ValueObjects;

namespace TommieDinner.Domain.MenuAggregate.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    private readonly List<MenuItem> _menuItems = new();

    public IReadOnlyList<MenuItem> MenuItems => _menuItems.AsReadOnly();

    public MenuSection(
        MenuSectionId id,
        string name,
        string description,
        List<MenuItem> menuItems) : base(id)
    {
        Name = name;
        Description = description;
        _menuItems = menuItems;
    }

    public static MenuSection CreateUnique(
        string name,
        string description,
        List<MenuItem>? items)
    {
        return new(
            MenuSectionId.CreateUnique(),
            name,
            description,
            items ?? new());
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private MenuSection() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
}