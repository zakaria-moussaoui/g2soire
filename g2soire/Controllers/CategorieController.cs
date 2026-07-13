using g2soire.Data;
using g2soire.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace g2soire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorieController : ControllerBase
    {
        private readonly AppContex _database;

        public CategorieController(AppContex database)
        {
            _database = database;
        }

        // GET: api/Categorie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorie>>> GetAll()
        {
            return await _database.Categories.ToListAsync();
        }

        // GET: api/Categorie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categorie>> GetById(int id)
        {
            var categorie = await _database.Categories.FindAsync(id);

            if (categorie == null)
                return NotFound();

            return categorie;
        }

        // POST: api/Categorie
        [HttpPost]
        public async Task<ActionResult<Categorie>> Create(Categorie categorie)
        {
            _database.Categories.Add(categorie);
            await _database.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetById),
                new { id = categorie.Id },
                categorie
            );
        }

        // PUT: api/Categorie/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Categorie categorie)
        {
            if (id != categorie.Id)
                return BadRequest();

            _database.Entry(categorie).State = EntityState.Modified;

            try
            {
                await _database.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _database.Categories.AnyAsync(c => c.Id == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        // DELETE: api/Categorie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var categorie = await _database.Categories.FindAsync(id);

            if (categorie == null)
                return NotFound();

            _database.Categories.Remove(categorie);
            await _database.SaveChangesAsync();

            return NoContent();
        }
    }
}