using DesignPatternsDemoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsDemoApi.Controllers;

[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/users")]
public class UsersV2Controller : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new[] { new User { Id = 1, Name = "From API V2" } });
    }
}
