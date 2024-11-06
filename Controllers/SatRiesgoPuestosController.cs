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
    public class SatRiesgoPuestosController : ControllerBase
    {
        private readonly ProyBd2bContext _context;

        public SatRiesgoPuestosController(ProyBd2bContext context)
        {
            _context = context;
        }

        // GET: api/SatRiesgoPuestos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SatRiesgoPuesto>>> GetSatRiesgoPuestos()
        {
            return await _context.SatRiesgoPuestos.ToListAsync();
        }

        // GET: api/SatRiesgoPuestos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SatRiesgoPuesto>> GetSatRiesgoPuesto(int id)
        {
            var satRiesgoPuesto = await _context.SatRiesgoPuestos.FindAsync(id);

            if (satRiesgoPuesto == null)
            {
                return NotFound();
            }

            return satRiesgoPuesto;
        }

        // PUT: api/SatRiesgoPuestos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSatRiesgoPuesto(int id, SatRiesgoPuesto satRiesgoPuesto)
        {
            if (id != satRiesgoPuesto.Id)
            {
                return BadRequest();
            }

            _context.Entry(satRiesgoPuesto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SatRiesgoPuestoExists(id))
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

        // POST: api/SatRiesgoPuestos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SatRiesgoPuesto>> PostSatRiesgoPuesto(SatRiesgoPuesto satRiesgoPuesto)
        {
            _context.SatRiesgoPuestos.Add(satRiesgoPuesto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSatRiesgoPuesto", new { id = satRiesgoPuesto.Id }, satRiesgoPuesto);
        }

        // DELETE: api/SatRiesgoPuestos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSatRiesgoPuesto(int id)
        {
            var satRiesgoPuesto = await _context.SatRiesgoPuestos.FindAsync(id);
            if (satRiesgoPuesto == null)
            {
                return NotFound();
            }

            _context.SatRiesgoPuestos.Remove(satRiesgoPuesto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SatRiesgoPuestoExists(int id)
        {
            return _context.SatRiesgoPuestos.Any(e => e.Id == id);
        }
    }
}
