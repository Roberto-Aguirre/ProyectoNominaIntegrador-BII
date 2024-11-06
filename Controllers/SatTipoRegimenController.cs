using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoNominaINTBII.Models;
using ProyectoNominaINTBII.ProyectoDbContext;

namespace ProyectoNominaINTBII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatTipoRegimenController : ControllerBase
    {
        private readonly ProyBd2bContext _context;

        public SatTipoRegimenController(ProyBd2bContext context)
        {
            _context = context;
        }

        // GET: api/SatTipoRegimen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SatTipoRegiman>>> GetSatTipoRegimen()
        {
            return await _context.SatTipoRegimen.ToListAsync();
        }

        // GET: api/SatTipoRegimen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SatTipoRegiman>> GetSatTipoRegimen(int id)
        {
            var satTipoRegimen = await _context.SatTipoRegimen.FindAsync(id);

            if (satTipoRegimen == null)
            {
                return NotFound();
            }

            return satTipoRegimen;
        }

        // PUT: api/SatTipoRegiman/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSatTipoRegimen(int id, SatTipoRegiman satTipoRegimen)
        {
            if (id != satTipoRegimen.Id)
            {
                return BadRequest();
            }

            _context.Entry(satTipoRegimen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SatTipoRegimenExists(id))
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

        // POST: api/SatTipoRegiman
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SatTipoRegiman>> PostSatTipoRegimen(SatTipoRegiman satTipoRegimen)
        {
            _context.SatTipoRegimen.Add(satTipoRegimen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSatTipoRegimen", new { id = satTipoRegimen.Id }, satTipoRegimen);
        }

        // DELETE: api/SatTipoRegimen/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSatTipoRegimen(int id)
        {
            var satTipoRegimen = await _context.SatTipoRegimen.FindAsync(id);
            if (satTipoRegimen == null)
            {
                return NotFound();
            }

            _context.SatTipoRegimen.Remove(satTipoRegimen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SatTipoRegimenExists(int id)
        {
            return _context.SatTipoRegimen.Any(e => e.Id == id);
        }
    }
}
