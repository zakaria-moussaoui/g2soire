using Microsoft.AspNetCore.Mvc;
using g2soire.Entities;
using g2soire.Services;

namespace g2soire.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FormationController : ControllerBase
{
    private readonly IServices _service;
    public FormationController(IServices service) => _service = service;

    // ========== INSCRIPTION ==========

    // POST /api/Formation/inscrire   body: { "userId": 1, "sessionId": 1 }
    [HttpPost("inscrire")]
    public IActionResult Inscrire([FromBody] InscriptionRequest request)
    {
        try
        {
            _service.Inscrire(request.UserId, request.SessionId);
            return Ok(new { message = "Inscription réussie." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    // GET /api/Formation/user/1
    [HttpGet("user/{userId}")]
    public IActionResult GetByUser(int userId)
        => Ok(_service.GetSessionsByUser(userId));

    // ========== CRUD FORMATION ==========

    // GET /api/Formation
    [HttpGet]
    public IActionResult GetAll()
        => Ok(_service.GetAllFormations());

    // GET /api/Formation/1
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var formation = _service.GetFormationById(id);
        if (formation == null)
            return NotFound(new { message = "Formation introuvable." });
        return Ok(formation);
    }

    // POST /api/Formation
    [HttpPost]
    public IActionResult Add([FromBody] Formation formation)
    {
        _service.AddFormation(formation);
        return Ok(new { message = "Formation ajoutée.", formation });
    }

    // PUT /api/Formation/1
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Formation formation)
    {
        _service.UpdateFormation(id, formation);
        return Ok(new { message = "Formation modifiée." });
    }

    // DELETE /api/Formation/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.DeleteFormation(id);
        return Ok(new { message = "Formation supprimée." });
    }

    // TEST
    [HttpGet("test")]
    public IActionResult Test() => Ok(new { message = "test ok" });
}

public class InscriptionRequest
{
    public int UserId { get; set; }
    public int SessionId { get; set; }
}

