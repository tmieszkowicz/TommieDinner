using ErrorOr;
using MediatR;
using TommieDinner.Application.Common.Interfaces.Persistence;
using TommieDinner.Domain.HostAggregate.ValueObjects;
using TommieDinner.Domain.MenuAggregate;
using TommieDinner.Domain.MenuAggregate.Entities;

namespace TommieDinner.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var menu = Menu.CreateUnique(
            hostId: HostId.CreateUnique(request.HostId),
            name: request.Name,
            description: request.Description,
            sections: request.Sections.ConvertAll(section => MenuSection.CreateUnique(
                name: section.Name,
                description: section.Description,
                items: section.Items.ConvertAll(item => MenuItem.CreateUnique(
                    item.Name,
                    item.Description)))));

        _menuRepository.Add(menu);

        return menu;
    }
}
