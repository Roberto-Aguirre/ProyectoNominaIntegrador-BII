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
    public class NominaDetalleController : ControllerBase
    {
        private readonly ProyDb2bContext _context;

        public NominaDetalleController(ProyDb2bContext context)
        {
            _context = context;
        }

        // GET: api/NominaDetalle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NominaDetalle>>> GetNominaDetalles()
        {
            return await _context.NominaDetalles.ToListAsync();
        }

        // GET: api/NominaDetalle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NominaDetalle>> GetNominaDetalle(int id)
        {
            var nominaDetalle = await _context.NominaDetalles.FindAsync(id);

            if (nominaDetalle == null)
            {
                return NotFound();
            }

            return nominaDetalle;
        }

        // PUT: api/NominaDetalle/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNominaDetalle(int id, NominaDetalle nominaDetalle)
        {
            if (id != nominaDetalle.Id)
            {
                return BadRequest();
            }

            _context.Entry(nominaDetalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NominaDetalleExists(id))
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

        // POST: api/NominaDetalle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NominaDetalle>> PostNominaDetalle(NominaDetalle nominaDetalle)
        {
            _context.NominaDetalles.Add(nominaDetalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNominaDetalle", new { id = nominaDetalle.Id }, nominaDetalle);
        }

        // DELETE: api/NominaDetalle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNominaDetalle(int id)
        {
            var nominaDetalle = await _context.NominaDetalles.FindAsync(id);
            if (nominaDetalle == null)
            {
                return NotFound();
            }

            _context.NominaDetalles.Remove(nominaDetalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NominaDetalleExists(int id)
        {
            return _context.NominaDetalles.Any(e => e.Id == id);
        }
    }
}
