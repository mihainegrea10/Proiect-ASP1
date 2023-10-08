using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect_ASP.Data;
using Proiect_ASP.Models;

namespace Proiect_ASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EchipaController : ControllerBase
    {
        private Context _Context;
        public EchipaController(Context context)
        {
            _Context = context;

        }
        [HttpGet]
        public async Task<IActionResult> GetEchipe()
        {
            return Ok(await _Context.echipas.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEchipa(Guid id)
        {
            var echipa = await _Context.echipas.FindAsync(id);

            if (echipa == null)
            {
                return NotFound();
            }

            return Ok(echipa);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEchipa(Echipa echipa)
        {
            if (ModelState.IsValid)
            {
                _Context.echipas.Add(echipa);
                await _Context.SaveChangesAsync();
                return CreatedAtAction("GetEchipa", new { id = echipa.Id }, echipa);
            }
            return BadRequest(ModelState);
        }
        private bool EchipaExists(Guid id)
        {
            return _Context.echipas.Any(e => e.Id == id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEchipa(Guid id, Echipa echipa)
        {
            if (id != echipa.Id)
            {
                return BadRequest();
            }

            _Context.Entry(echipa).State = EntityState.Modified;

            try
            {
                await _Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EchipaExists(id))
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
        public async Task<IActionResult> DeleteEchipa(Guid id)
        {
            var echipa = await _Context.echipas.FindAsync(id);
            if (echipa == null)
            {
                return NotFound();
            }

            _Context.echipas.Remove(echipa);
            await _Context.SaveChangesAsync();

            return NoContent();
        }



    }
}
