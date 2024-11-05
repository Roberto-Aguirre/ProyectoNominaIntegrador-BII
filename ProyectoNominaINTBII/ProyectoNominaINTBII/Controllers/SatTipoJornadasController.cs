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
    public class SatTipoJornadasController : ControllerBase
    {
        private readonly ProyBd2bContext _context;

        public SatTipoJornadasController(ProyBd2bContext context)
        {
            _context = context;
        }

        // GET: api/SatTipoJornadas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SatTipoJornada>>> GetSatTipoJornada()
        {
            return await _context.SatTipoJornada.ToListAsync();
        }

        // GET: api/SatTipoJornadas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SatTipoJornada>> GetSatTipoJornada(int id)
        {
            var satTipoJornada = await _context.SatTipoJornada.FindAsync(id);

            if (satTipoJornada == null)
            {
                return NotFound();
            }

            return satTipoJornada;
        }

        // PUT: api/SatTipoJornadas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSatTipoJornada(int id, SatTipoJornada satTipoJornada)
        {
            if (id != satTipoJornada.Id)
            {
                return BadRequest();
            }

            _context.Entry(satTipoJornada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SatTipoJornadaExists(id))
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

        // POST: api/SatTipoJornadas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SatTipoJornada>> PostSatTipoJornada(SatTipoJornada satTipoJornada)
        {
            _context.SatTipoJornada.Add(satTipoJornada);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSatTipoJornada", new { id = satTipoJornada.Id }, satTipoJornada);
        }

        // DELETE: api/SatTipoJornadas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSatTipoJornada(int id)
        {
            var satTipoJornada = await _context.SatTipoJornada.FindAsync(id);
            if (satTipoJornada == null)
            {
                return NotFound();
            }

            _context.SatTipoJornada.Remove(satTipoJornada);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SatTipoJornadaExists(int id)
        {
            return _context.SatTipoJornada.Any(e => e.Id == id);
        }
    }
}
