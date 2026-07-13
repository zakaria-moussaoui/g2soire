using Microsoft.AspNetCore.Mvc;
using g2soire.Entities;
using g2soire.Services;

namespace g2soire.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ModuleController : ControllerBase
{
    private readonly IServices _service;
    public ModuleController(IServices service) => _service = service;

    // GET /api/Module
    [HttpGet]
    public IActionResult GetAll()
        => Ok(_service.GetAllModules());

    // GET /api/Module/1
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var module = _service.GetModuleById(id);
        if (module == null)
            return NotFound(new { message = "Module introuvable." });
        return Ok(module);
    }

    // POST /api/Module
    [HttpPost]
    public IActionResult Add([FromBody] Module module)
    {
        _service.AddModule(module);
        return Ok(new { message = "Module ajouté.", module });
    }

    // PUT /api/Module/1
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Module module)
    {
        _service.UpdateModule(id, module);
        return Ok(new { message = "Module modifié." });
    }

    // DELETE /api/Module/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.DeleteModule(id);
        return Ok(new { message = "Module supprimé." });
    }
}