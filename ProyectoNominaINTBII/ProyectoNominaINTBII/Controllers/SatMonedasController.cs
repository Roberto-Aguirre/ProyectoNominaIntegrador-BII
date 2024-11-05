using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoNominaINTBII.Data;
using ProyectoNominaINTBII.Models;

namespace ProyectoNominaINTBII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatMonedasController : ControllerBase
    {
        private readonly ProyBd2bContext _context;

        public SatMonedasController(ProyBd2bContext context)
        {
            _context = context;
        }

        // GET: api/SatMonedas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SatMoneda>>> GetSatMoneda()
        {
            return await _context.SatMoneda.ToListAsync();
        }

        // GET: api/SatMonedas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SatMoneda>> GetSatMoneda(int id)
        {
            var satMoneda = await _context.SatMoneda.FindAsync(id);

            if (satMoneda == null)
            {
                return NotFound();
            }

            return satMoneda;
        }

        // PUT: api/SatMonedas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSatMoneda(int id, SatMoneda satMoneda)
        {
            if (id != satMoneda.Id)
            {
                return BadRequest();
            }

            _context.Entry(satMoneda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SatMonedaExists(id))
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

        // POST: api/SatMonedas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SatMoneda>> PostSatMoneda(SatMoneda satMoneda)
        {
            _context.SatMoneda.Add(satMoneda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSatMoneda", new { id = satMoneda.Id }, satMoneda);
        }

        // DELETE: api/SatMonedas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSatMoneda(int id)
        {
            var satMoneda = await _context.SatMoneda.FindAsync(id);
            if (satMoneda == null)
            {
                return NotFound();
            }

            _context.SatMoneda.Remove(satMoneda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SatMonedaExists(int id)
        {
            return _context.SatMoneda.Any(e => e.Id == id);
        }
    }
}
