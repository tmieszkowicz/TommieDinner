using FluentAssertions;
using TommieDinner.Application.Menus.Commands.CreateMenu;
using TommieDinner.Domain.MenuAggregate;
using TommieDinner.Domain.MenuAggregate.Entities;

namespace TommieDinner.Application.UnitTests.Menus.TestUtils.Menus.Extensions;
public static partial class MenuExtensions
{
    public static void ValidateCreatedFrom(this Menu menu, CreateMenuCommand command)
    {
        menu.Name.Should().Be(command.Name);
        menu.Description.Should().Be(command.Description);
        menu.MenuSections.Should().HaveSameCount(command.Sections);
        menu.MenuSections.Zip(command.Sections).ToList().ForEach(pair => ValidateSection(pair.First, pair.Second));
    }

    private static void ValidateSection(MenuSection section, CreateMenuSectionCommand command)
    {
        throw new NotImplementedException();
    }
    private static void ValidateItem(MenuItem item, CreateMenuItemCommand command)
    {
        throw new NotImplementedException();
    }
}