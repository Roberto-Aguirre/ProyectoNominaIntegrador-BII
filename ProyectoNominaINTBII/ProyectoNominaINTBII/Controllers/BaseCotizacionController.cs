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
    public class BaseCotizacionController : ControllerBase
    {
        private readonly Prueba3Context _context;

        public BaseCotizacionController(Prueba3Context context)
        {
            _context = context;
        }

        // GET: api/BaseCotizacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaseCotizacion>>> GetBaseCotizacions()
        {
            return await _context.BaseCotizacions.ToListAsync();
        }

        // GET: api/BaseCotizacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseCotizacion>> GetBaseCotizacion(int id)
        {
            var baseCotizacion = await _context.BaseCotizacions.FindAsync(id);

            if (baseCotizacion == null)
            {
                return NotFound();
            }

            return baseCotizacion;
        }

        // PUT: api/BaseCotizacion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaseCotizacion(int id, BaseCotizacion baseCotizacion)
        {
            if (id != baseCotizacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(baseCotizacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaseCotizacionExists(id))
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

        // POST: api/BaseCotizacion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BaseCotizacion>> PostBaseCotizacion(BaseCotizacion baseCotizacion)
        {
            _context.BaseCotizacions.Add(baseCotizacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBaseCotizacion", new { id = baseCotizacion.Id }, baseCotizacion);
        }

        // DELETE: api/BaseCotizacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaseCotizacion(int id)
        {
            var baseCotizacion = await _context.BaseCotizacions.FindAsync(id);
            if (baseCotizacion == null)
            {
                return NotFound();
            }

            _context.BaseCotizacions.Remove(baseCotizacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BaseCotizacionExists(int id)
        {
            return _context.BaseCotizacions.Any(e => e.Id == id);
        }
    }
}
