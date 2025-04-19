using FluentValidation;

namespace TommieDinner.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandlerValidator : AbstractValidator<CreateMenuCommand>
{
    public CreateMenuCommandHandlerValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Sections).NotEmpty();
    }
}