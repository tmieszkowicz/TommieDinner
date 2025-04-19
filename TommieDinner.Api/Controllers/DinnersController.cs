
using Microsoft.AspNetCore.Mvc;

namespace TommieDinner.Api.Controllers;

[Route("[controller]")]
public class DinnersController : ApiController
{
    [HttpGet]
    public IActionResult ListDinners()
    {
        return Ok(Array.Empty<string>());
    }
}