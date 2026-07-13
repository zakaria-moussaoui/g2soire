using Microsoft.AspNetCore.Mvc;
using g2soire.Entities;
using g2soire.Services;

namespace g2soire.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SessionController : ControllerBase
{
    private readonly IServices _service;
    public SessionController(IServices service) => _service = service;

    // GET /api/Session
    [HttpGet]
    public IActionResult GetAll()
        => Ok(_service.GetAllSessions());

    // GET /api/Session/1
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var session = _service.GetSessionById(id);
        if (session == null)
            return NotFound(new { message = "Session introuvable." });
        return Ok(session);
    }

    // POST /api/Session
    [HttpPost]
    public IActionResult Add([FromBody] Session session)
    {
        _service.AddSession(session);
        return Ok(new { message = "Session ajoutée.", session });
    }

    // PUT /api/Session/1
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Session session)
    {
        _service.UpdateSession(id, session);
        return Ok(new { message = "Session modifiée." });
    }

    // DELETE /api/Session/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.DeleteSession(id);
        return Ok(new { message = "Session supprimée." });
    }
}