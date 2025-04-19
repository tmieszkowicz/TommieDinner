using TommieDinner.Domain.Common.Models;
using TommieDinner.Domain.Menu.ValueObjects;

namespace TommieDinner.Domain.MenuAggregate.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    private MenuItem(MenuItemId menuItemId, string name, string description) : base(menuItemId)
    {
        Name = name;
        Description = description;
    }

    public static MenuItem CreateUnique(string name, string description)
    {
        return new(MenuItemId.CreateUnique(), name, description);
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private MenuItem() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
}