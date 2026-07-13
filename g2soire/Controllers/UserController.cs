using Microsoft.AspNetCore.Mvc;
using g2soire.Entities;
using g2soire.Services;

namespace g2soire.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IServices _service;
    public UserController(IServices service) => _service = service;

    [HttpGet("test")]
    public IActionResult Test() => Ok(new { message = "user ok" });

    [HttpGet]
    public IActionResult GetAll()
        => Ok(_service.GetAllUsers());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _service.GetUserById(id);
        if (user == null)
            return NotFound(new { message = "Utilisateur introuvable." });
        return Ok(user);
    }

    [HttpPost]
    public IActionResult Add([FromBody] User user)
    {
        _service.AddUser(user);
        return Ok(new { message = "Utilisateur créé.", user });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] User user)
    {
        _service.UpdateUser(id, user);
        return Ok(new { message = "Utilisateur modifié." });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.DeleteUser(id);
        return Ok(new { message = "Utilisateur supprimé." });
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var user = _service.Authentifier(request.Login, request.Password);
        if (user == null)
            return Unauthorized(new { message = "Login ou mot de passe incorrect." });

        return Ok(new { message = "Connexion réussie.", user.Id, user.Nom, user.Prenom, user.Login });
    }
}

public class LoginRequest
{
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
}