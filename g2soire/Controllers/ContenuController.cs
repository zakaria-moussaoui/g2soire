using Microsoft.AspNetCore.Mvc;
using g2soire.Entities;
using g2soire.Services;

namespace g2soire.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContenuController : ControllerBase
{
    private readonly IServices _service;
    public ContenuController(IServices service) => _service = service;

    // GET /api/Contenu
    [HttpGet]
    public IActionResult GetAll()
        => Ok(_service.GetAllContenus());

    // GET /api/Contenu/1
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var contenu = _service.GetContenuById(id);
        if (contenu == null)
            return NotFound(new { message = "Contenu introuvable." });
        return Ok(contenu);
    }

    // POST /api/Contenu
    [HttpPost]
    public IActionResult Add([FromBody] Contenu contenu)
    {
        _service.AddContenu(contenu);
        return Ok(new { message = "Contenu ajouté.", contenu });
    }

    // PUT /api/Contenu/1
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Contenu contenu)
    {
        _service.UpdateContenu(id, contenu);
        return Ok(new { message = "Contenu modifié." });
    }

    // DELETE /api/Contenu/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.DeleteContenu(id);
        return Ok(new { message = "Contenu supprimé." });
    }
}