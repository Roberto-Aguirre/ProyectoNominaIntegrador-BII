using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoNominaINTBII.ProyectoDbContext;


using ProyectoNominaINTBII.Models;

namespace ProyectoNominaINTBII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatMunicipiosController : ControllerBase
    {
        private readonly ProyBd2bContext _context;

        public SatMunicipiosController(ProyBd2bContext context)
        {
            _context = context;
        }

        // GET: api/SatMunicipios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SatMunicipio>>> GetSatMunicipios()
        {
            return await _context.SatMunicipios.ToListAsync();
        }

        // GET: api/SatMunicipios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SatMunicipio>> GetSatMunicipio(int id)
        {
            var satMunicipio = await _context.SatMunicipios.FindAsync(id);

            if (satMunicipio == null)
            {
                return NotFound();
            }

            return satMunicipio;
        }

        // PUT: api/SatMunicipios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSatMunicipio(int id, SatMunicipio satMunicipio)
        {
            if (id != satMunicipio.Id)
            {
                return BadRequest();
            }

            _context.Entry(satMunicipio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SatMunicipioExists(id))
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

        // POST: api/SatMunicipios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SatMunicipio>> PostSatMunicipio(SatMunicipio satMunicipio)
        {
            _context.SatMunicipios.Add(satMunicipio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSatMunicipio", new { id = satMunicipio.Id }, satMunicipio);
        }

        // DELETE: api/SatMunicipios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSatMunicipio(int id)
        {
            var satMunicipio = await _context.SatMunicipios.FindAsync(id);
            if (satMunicipio == null)
            {
                return NotFound();
            }

            _context.SatMunicipios.Remove(satMunicipio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SatMunicipioExists(int id)
        {
            return _context.SatMunicipios.Any(e => e.Id == id);
        }
    }
}
