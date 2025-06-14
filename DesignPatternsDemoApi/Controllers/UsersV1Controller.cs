using DesignPatternsDemoApi.Interfaces;
using DesignPatternsDemoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DesignPatternsDemoApi.Controllers;

[Authorize]
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/users")]
public class UsersV1Controller : ControllerBase
{
    private readonly IUserService _userService;

    public UsersV1Controller(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_userService.GetAllUsers());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _userService.GetUserById(id);
        return user is null ? NotFound() : Ok(user);
    }

    [HttpPost]
    public IActionResult Add(User user)
    {
        _userService.AddUser(user);
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }
}
