using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect_ASP.Data;
using Proiect_ASP.Models;

namespace Proiect_ASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JucatorController : ControllerBase
    {
        private Context _Context;
        public JucatorController(Context context)
        {
            _Context = context;

        }
        [HttpGet]
        public async Task<IActionResult> GetJucatori()
        {
            var jucatori = await _Context.jucators.ToListAsync();
            return Ok(jucatori);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJucator(Guid id)
        {
            var jucator = await _Context.jucators.FindAsync(id);

            if (jucator == null)
            {
                return NotFound();
            }

            return Ok(jucator);
        }
        [HttpPost]
        public async Task<IActionResult> CreateJucator(Jucator jucator)
        {
            if (ModelState.IsValid)
            {
                jucator.Id = Guid.NewGuid(); // Generate a new Guid for the entity
                _Context.jucators.Add(jucator);
                await _Context.SaveChangesAsync();
                return CreatedAtAction("GetJucator", new { id = jucator.Id }, jucator);
            }
            return BadRequest(ModelState);
        }
        private bool JucatorExists(Guid id)
        {
            return _Context.jucators.Any(e => e.Id == id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJucator(Guid id, Jucator jucator)
        {
            if (id != jucator.Id)
            {
                return BadRequest();
            }

            _Context.Entry(jucator).State = EntityState.Modified;

            try
            {
                await _Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JucatorExists(id))
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
        public async Task<IActionResult> DeleteJucator(Guid id)
        {
            var jucator = await _Context.jucators.FindAsync(id);
            if (jucator == null)
            {
                return NotFound();
            }

            _Context.jucators.Remove(jucator);
            await _Context.SaveChangesAsync();

            return NoContent();
        }
    }
}
