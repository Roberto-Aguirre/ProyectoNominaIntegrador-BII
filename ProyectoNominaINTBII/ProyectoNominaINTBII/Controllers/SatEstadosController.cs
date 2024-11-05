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
    public class SatEstadosController : ControllerBase
    {
        private readonly ProyBd2bContext _context;

        public SatEstadosController(ProyBd2bContext context)
        {
            _context = context;
        }

        // GET: api/SatEstados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SatEstado>>> GetSatEstados()
        {
            return await _context.SatEstados.ToListAsync();
        }

        // GET: api/SatEstados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SatEstado>> GetSatEstado(int id)
        {
            var satEstado = await _context.SatEstados.FindAsync(id);

            if (satEstado == null)
            {
                return NotFound();
            }

            return satEstado;
        }

        // PUT: api/SatEstados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSatEstado(int id, SatEstado satEstado)
        {
            if (id != satEstado.Id)
            {
                return BadRequest();
            }

            _context.Entry(satEstado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SatEstadoExists(id))
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

        // POST: api/SatEstados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SatEstado>> PostSatEstado(SatEstado satEstado)
        {
            _context.SatEstados.Add(satEstado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSatEstado", new { id = satEstado.Id }, satEstado);
        }

        // DELETE: api/SatEstados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSatEstado(int id)
        {
            var satEstado = await _context.SatEstados.FindAsync(id);
            if (satEstado == null)
            {
                return NotFound();
            }

            _context.SatEstados.Remove(satEstado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SatEstadoExists(int id)
        {
            return _context.SatEstados.Any(e => e.Id == id);
        }
    }
}
