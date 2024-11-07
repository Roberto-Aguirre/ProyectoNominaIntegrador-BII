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
    public class SatPaisController : ControllerBase
    {
        private readonly Prueba3Context _context;  private readonly IMapper _automapper;

        public SatPaisController(Prueba3Context context, IMapper mapper)
        {
             _context = context;            _automapper = mapper;   
        }

        // GET: api/SatPais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SatPaiDTO>>> GetSatPais()
        {
            return _automapper.Map<List<SatPaiDTO>>(await _context.SatPais.ToListAsync());
        }

        // GET: api/SatPais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SatPaiDTO>> GetSatPai(int id)
        {
            var satPai = _automapper.Map<SatPaiDTO>(await _context.SatPais.FindAsync(id));

            if (satPai == null)
            {
                return NotFound();
            }

            return satPai;
        }

        // PUT: api/SatPais/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSatPai(int id, SatPai satPai)
        {
            if (id != satPai.Id)
            {
                return BadRequest();
            }

            _context.Entry(satPai).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SatPaiExists(id))
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

        // POST: api/SatPais
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SatPai>> PostSatPai(SatPai satPai)
        {
            _context.SatPais.Add(satPai);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSatPai", new { id = satPai.Id }, satPai);
        }

        // DELETE: api/SatPais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSatPai(int id)
        {
            var satPai = await _context.SatPais.FindAsync(id);
            if (satPai == null)
            {
                return NotFound();
            }

            _context.SatPais.Remove(satPai);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SatPaiExists(int id)
        {
            return _context.SatPais.Any(e => e.Id == id);
        }
    }
}
