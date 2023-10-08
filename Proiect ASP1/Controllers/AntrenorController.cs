using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect_ASP.Data;
using Proiect_ASP.Models;

namespace Proiect_ASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AntrenorController : ControllerBase
    {
        private Context _Context;
        public AntrenorController(Context context)
        {
            _Context = context;

        }
        [HttpGet]
        public async Task<IActionResult> GetAntrenori()
        {
            var antrenori = await _Context.antrenors.ToListAsync();
            return Ok(antrenori);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAntrenor(Guid id)
        {
            var antrenor = await _Context.antrenors.FindAsync(id);

            if (antrenor == null)
            {
                return NotFound();
            }

            return Ok(antrenor);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAntrenor(Antrenor antrenor)
        {
            if (ModelState.IsValid)
            {
                antrenor.Id = Guid.NewGuid(); // Generate a new Guid for the entity
                _Context.antrenors.Add(antrenor);
                await _Context.SaveChangesAsync();
                return CreatedAtAction("GetAntrenor", new { id = antrenor.Id }, antrenor);
            }
            return BadRequest(ModelState);
        }
        private bool AntrenorExists(Guid id)
        {
            return _Context.antrenors.Any(e => e.Id == id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAntrenor(Guid id, Antrenor antrenor)
        {
            if (id != antrenor.Id)
            {
                return BadRequest();
            }

            _Context.Entry(antrenor).State = EntityState.Modified;

            try
            {
                await _Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AntrenorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAntrenor(Guid id)
        {
            var antrenor = await _Context.antrenors.FindAsync(id);
            if (antrenor == null)
            {
                return NotFound();
            }

            _Context.antrenors.Remove(antrenor);
            await _Context.SaveChangesAsync();

            return NoContent();
        }
    }
}
