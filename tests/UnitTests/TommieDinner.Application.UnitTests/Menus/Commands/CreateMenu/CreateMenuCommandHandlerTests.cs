using FluentAssertions;
using Moq;
using TommieDinner.Application.Common.Interfaces.Persistence;
using TommieDinner.Application.Menus.Commands.CreateMenu;
using TommieDinner.Application.UnitTests.Menus.Commands.TestUtils;
using TommieDinner.Application.UnitTests.Menus.TestUtils.Menus.Extensions;

namespace TommieDinner.Application.UnitTests.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandlerTests
{
    private readonly CreateMenuCommandHandler _handler;
    private readonly Mock<IMenuRepository> _mockMenuRepository;
    public CreateMenuCommandHandlerTests()
    {
        _mockMenuRepository = new Mock<IMenuRepository>();
        _handler = new CreateMenuCommandHandler(_mockMenuRepository.Object);
    }
    //SystemUnderTest_Scenario_ExpectedOutcome
    [Theory]
    [MemberData(nameof(ValidCreateMenuCommands))]
    public async Task HandleCreateMenuCommand_WhenMenuIsValid_ShouldCreateAndReturnMenu(CreateMenuCommand createMenuCommand)
    {
        //Act
        var result = await _handler.Handle(createMenuCommand, default);

        //Assert
        result.IsError.Should().BeFalse();
        result.Value.ValidateCreatedFrom(createMenuCommand);

        //_mockMenuRepository.Verify(m => m.Add(result.Value));
    }

    public static IEnumerable<object[]> ValidCreateMenuCommands()
    {
        yield return new[] { CreateMenuCommandUtils.CreateCommand() };

        yield return new[]
        {
            CreateMenuCommandUtils.CreateCommand(
                sections: CreateMenuCommandUtils.CreateSectionsCommand(sectionCount: 3))
        };

        yield return new[]
        {
            CreateMenuCommandUtils.CreateCommand(
                sections: CreateMenuCommandUtils.CreateSectionsCommand(sectionCount: 3, items: CreateMenuCommandUtils.CreateItemsCommand(itemCount: 3)))
        };
    }
}