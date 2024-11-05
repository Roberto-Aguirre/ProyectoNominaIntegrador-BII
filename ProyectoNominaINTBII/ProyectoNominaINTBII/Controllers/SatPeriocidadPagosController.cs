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
    public class SatPeriocidadPagosController : ControllerBase
    {
        private readonly ProyBd2bContext _context;

        public SatPeriocidadPagosController(ProyBd2bContext context)
        {
            _context = context;
        }

        // GET: api/SatPeriocidadPagos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SatPeriocidadPago>>> GetSatPeriocidadPagos()
        {
            return await _context.SatPeriocidadPagos.ToListAsync();
        }

        // GET: api/SatPeriocidadPagos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SatPeriocidadPago>> GetSatPeriocidadPago(int id)
        {
            var satPeriocidadPago = await _context.SatPeriocidadPagos.FindAsync(id);

            if (satPeriocidadPago == null)
            {
                return NotFound();
            }

            return satPeriocidadPago;
        }

        // PUT: api/SatPeriocidadPagos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSatPeriocidadPago(int id, SatPeriocidadPago satPeriocidadPago)
        {
            if (id != satPeriocidadPago.Id)
            {
                return BadRequest();
            }

            _context.Entry(satPeriocidadPago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SatPeriocidadPagoExists(id))
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

        // POST: api/SatPeriocidadPagos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SatPeriocidadPago>> PostSatPeriocidadPago(SatPeriocidadPago satPeriocidadPago)
        {
            _context.SatPeriocidadPagos.Add(satPeriocidadPago);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSatPeriocidadPago", new { id = satPeriocidadPago.Id }, satPeriocidadPago);
        }

        // DELETE: api/SatPeriocidadPagos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSatPeriocidadPago(int id)
        {
            var satPeriocidadPago = await _context.SatPeriocidadPagos.FindAsync(id);
            if (satPeriocidadPago == null)
            {
                return NotFound();
            }

            _context.SatPeriocidadPagos.Remove(satPeriocidadPago);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SatPeriocidadPagoExists(int id)
        {
            return _context.SatPeriocidadPagos.Any(e => e.Id == id);
        }
    }
}
