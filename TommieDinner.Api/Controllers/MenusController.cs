using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TommieDinner.Application.Menus.Commands.CreateMenu;
using TommieDinner.Contracts.Menus;

namespace TommieDinner.Api.Controllers;

[Route("hosts/{hostId}/menus")]
public class MenusController : ApiController
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public MenusController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenu(
        CreateMenuRequest request,
        string hostId)
    {
        var command = _mapper.Map<CreateMenuCommand>((request, hostId));

        var createMenuResult = await _mediator.Send(command);

        return createMenuResult.Match(
            menu => Ok(_mapper.Map<MenuResponse>(menu)),
            errors => Problem(errors));
    }
}