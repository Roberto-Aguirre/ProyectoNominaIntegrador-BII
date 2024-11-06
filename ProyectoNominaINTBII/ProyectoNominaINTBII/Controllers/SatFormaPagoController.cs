using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoNominaINTBII.Models;
using ProyectoNominaINTBII.DTOS;
using ProyectoNominaINTBII.Data;

namespace ProyectoNominaINTBII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatFormaPagoController : ControllerBase
    {
        private readonly Prueba3Context _context;

        public SatFormaPagoController(Prueba3Context context)
        {
            _context = context;
        }

        // GET: api/SatFormaPago
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SatFormaPago>>> GetSatFormaPagos()
        {
            return await _context.SatFormaPagos.ToListAsync();
        }

        // GET: api/SatFormaPago/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SatFormaPago>> GetSatFormaPago(int id)
        {
            var satFormaPago = await _context.SatFormaPagos.FindAsync(id);

            if (satFormaPago == null)
            {
                return NotFound();
            }

            return satFormaPago;
        }

        // PUT: api/SatFormaPago/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSatFormaPago(int id, SatFormaPago satFormaPago)
        {
            if (id != satFormaPago.Id)
            {
                return BadRequest();
            }

            _context.Entry(satFormaPago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SatFormaPagoExists(id))
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

        // POST: api/SatFormaPago
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SatFormaPago>> PostSatFormaPago(SatFormaPago satFormaPago)
        {
            _context.SatFormaPagos.Add(satFormaPago);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSatFormaPago", new { id = satFormaPago.Id }, satFormaPago);
        }

        // DELETE: api/SatFormaPago/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSatFormaPago(int id)
        {
            var satFormaPago = await _context.SatFormaPagos.FindAsync(id);
            if (satFormaPago == null)
            {
                return NotFound();
            }

            _context.SatFormaPagos.Remove(satFormaPago);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SatFormaPagoExists(int id)
        {
            return _context.SatFormaPagos.Any(e => e.Id == id);
        }
    }
}
