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

using AutoMapper; namespace ProyectoNominaINTBII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatTipoHorasController : ControllerBase
    {
        private readonly ProyDb2bContext _context;  private readonly IMapper _automapper;

        public SatTipoHorasController(ProyDb2bContext context, IMapper mapper)
        {
             _context = context;            _automapper = mapper;   
        }

        // GET: api/SatTipoHoras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SatTipoHoraDTO>>> GetSatTipoHoras()
        {
            return _automapper.Map<List<SatTipoHoraDTO>>(await _context.SatTipoHoras.ToListAsync());
        }

        // GET: api/SatTipoHoras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SatTipoHoraDTO>> GetSatTipoHora(int id)
        {
            var satTipoHora = _automapper.Map<SatTipoHoraDTO>(await _context.SatTipoHoras.FindAsync(id));

            if (satTipoHora == null)
            {
                return NotFound();
            }

            return satTipoHora;
        }

        // PUT: api/SatTipoHoras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSatTipoHora(int id, SatTipoHora satTipoHora)
        {
            if (id != satTipoHora.Id)
            {
                return BadRequest();
            }

            _context.Entry(satTipoHora).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SatTipoHoraExists(id))
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

        // POST: api/SatTipoHoras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SatTipoHora>> PostSatTipoHora(SatTipoHora satTipoHora)
        {
            _context.SatTipoHoras.Add(satTipoHora);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSatTipoHora", new { id = satTipoHora.Id }, satTipoHora);
        }

        // DELETE: api/SatTipoHoras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSatTipoHora(int id)
        {
            var satTipoHora = await _context.SatTipoHoras.FindAsync(id);
            if (satTipoHora == null)
            {
                return NotFound();
            }

            _context.SatTipoHoras.Remove(satTipoHora);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SatTipoHoraExists(int id)
        {
            return _context.SatTipoHoras.Any(e => e.Id == id);
        }
    }
}
