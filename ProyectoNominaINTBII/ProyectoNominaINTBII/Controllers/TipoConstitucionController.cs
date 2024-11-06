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

namespace ProyectoNominaINTBII.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoConstitucionController : ControllerBase
    {
        private readonly Prueba3Context _context;

        public TipoConstitucionController(Prueba3Context context)
        {
            _context = context;
        }

        // GET: api/TipoConstitucion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoConstitucion>>> GetTipoConstitucions()
        {
            return await _context.TipoConstitucions.ToListAsync();
        }

        // GET: api/TipoConstitucion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoConstitucion>> GetTipoConstitucion(int id)
        {
            var tipoConstitucion = await _context.TipoConstitucions.FindAsync(id);

            if (tipoConstitucion == null)
            {
                return NotFound();
            }

            return tipoConstitucion;
        }

        // PUT: api/TipoConstitucion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoConstitucion(int id, TipoConstitucion tipoConstitucion)
        {
            if (id != tipoConstitucion.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoConstitucion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoConstitucionExists(id))
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

        // POST: api/TipoConstitucion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoConstitucion>> PostTipoConstitucion(TipoConstitucion tipoConstitucion)
        {
            _context.TipoConstitucions.Add(tipoConstitucion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoConstitucion", new { id = tipoConstitucion.Id }, tipoConstitucion);
        }

        // DELETE: api/TipoConstitucion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoConstitucion(int id)
        {
            var tipoConstitucion = await _context.TipoConstitucions.FindAsync(id);
            if (tipoConstitucion == null)
            {
                return NotFound();
            }

            _context.TipoConstitucions.Remove(tipoConstitucion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoConstitucionExists(int id)
        {
            return _context.TipoConstitucions.Any(e => e.Id == id);
        }
    }
}
