using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect_ASP.Data;
using Proiect_ASP.Models;
using Proiect_ASP1.Models;
using Proiect_ASP1.Models.DTOs;
using Proiect_ASP1.Services.DemoService;

namespace Proiect_ASP1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImpresarController : ControllerBase
    {
        private Context _Context;
        public ImpresarController(Context context)
        {
            _Context = context;

        }
        private readonly IDemoService _demoService;
        public ImpresarController(IDemoService demoService)
        {
            _demoService = demoService;
        }
        
        [HttpGet]
        public IActionResult GetBynume_familie(string nume_familie)
        {
            var result = _demoService.GetDataMappedBynume_familie(nume_familie);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetImpresari()
        {
            var impresar = await _Context.impresars.ToListAsync();
            return Ok(impresar);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetImpresar(Guid id)
        {
            var impresar = await _Context.impresars.FindAsync(id);

            if (impresar == null)
            {
                return NotFound();
            }

            return Ok(impresar);
        }
        [HttpPost]
        public async Task<IActionResult> CreateImpresar(Impresar impresar)
        {
            if (ModelState.IsValid)
            {
                impresar.Id = Guid.NewGuid(); // Generate a new Guid for the entity
                 _Context.impresars.Add(impresar);
                await _Context.SaveChangesAsync();
                return CreatedAtAction("GetImpresar", new { id = impresar.Id }, impresar);
            }
            return BadRequest(ModelState);
        }
        private bool ImpresarExists(Guid id)
        {
            return _Context.impresars.Any(e => e.Id == id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateImpresar(Guid id, Impresar impresar)
        {
            if (id != impresar.Id)
            {
                return BadRequest();
            }

            _Context.Entry(impresar).State = EntityState.Modified;

            try
            {
                await _Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImpresarExists(id))
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
        public async Task<IActionResult> DeleteImpresar(Guid id)
        {
            var impresar = await _Context.impresars.FindAsync(id);
            if (impresar == null)
            {
                return NotFound();
            }

            _Context.impresars.Remove(impresar);
            await _Context.SaveChangesAsync();

            return NoContent();
        }
        
        
    }
}
