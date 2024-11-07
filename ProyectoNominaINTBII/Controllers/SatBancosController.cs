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
    public class SatBancosController : ControllerBase
    {
        private readonly Prueba3Context _context;  private readonly IMapper _automapper;

        public SatBancosController(Prueba3Context context, IMapper mapper)
        {
             _context = context;            _automapper = mapper;   
        }

        // GET: api/SatBancos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SatBancoDTO>>> GetSatBancos()
        {
            return _automapper.Map<List<SatBancoDTO>>(await _context.SatBancos.ToListAsync());
        }

        // GET: api/SatBancos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SatBancoDTO>> GetSatBanco(int id)
        {
            var satBanco = _automapper.Map<SatBancoDTO>(await _context.SatBancos.FindAsync(id));

            if (satBanco == null)
            {
                return NotFound();
            }

            return satBanco;
        }

        // PUT: api/SatBancos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSatBanco(int id, SatBanco satBanco)
        {
            if (id != satBanco.Id)
            {
                return BadRequest();
            }

            _context.Entry(satBanco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SatBancoExists(id))
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

        // POST: api/SatBancos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SatBanco>> PostSatBanco(SatBanco satBanco)
        {
            _context.SatBancos.Add(satBanco);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSatBanco", new { id = satBanco.Id }, satBanco);
        }

        // DELETE: api/SatBancos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSatBanco(int id)
        {
            var satBanco = await _context.SatBancos.FindAsync(id);
            if (satBanco == null)
            {
                return NotFound();
            }

            _context.SatBancos.Remove(satBanco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SatBancoExists(int id)
        {
            return _context.SatBancos.Any(e => e.Id == id);
        }
    }
}
