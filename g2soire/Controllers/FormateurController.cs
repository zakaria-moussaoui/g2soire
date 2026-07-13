using Microsoft.AspNetCore.Mvc;
using g2soire.Entities;
using g2soire.Services;

namespace g2soire.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FormateurController : ControllerBase
{
    private readonly IServices _service;
    public FormateurController(IServices service) => _service = service;

    // GET /api/Formateur  -> tous les formateurs
    [HttpGet]
    public IActionResult GetAll()
        => Ok(_service.GetAllFormateurs());

    // GET /api/Formateur/1  -> un formateur par id
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var formateur = _service.GetFormateurById(id);
        if (formateur == null)
            return NotFound(new { message = "Formateur introuvable." });
        return Ok(formateur);
    }

    // POST /api/Formateur  -> ajouter un formateur
    [HttpPost]
    public IActionResult Add([FromBody] Formateur formateur)
    {
        _service.AddFormateur(formateur);
        return Ok(new { message = "Formateur ajouté.", formateur });
    }

    // PUT /api/Formateur/1  -> modifier un formateur
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Formateur formateur)
    {
        _service.UpdateFormateur(id, formateur);
        return Ok(new { message = "Formateur modifié." });
    }

    // DELETE /api/Formateur/1  -> supprimer un formateur
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.DeleteFormateur(id);
        return Ok(new { message = "Formateur supprimé." });
    }
}