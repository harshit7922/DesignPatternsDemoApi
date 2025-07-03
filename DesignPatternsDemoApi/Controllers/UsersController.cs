using DesignPatternsDemoApi.Interfaces;
using DesignPatternsDemoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsDemoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _userService.GetUserById(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpPost]
    public IActionResult Create(User user)
    {
        _userService.AddUser(user);
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }
}
