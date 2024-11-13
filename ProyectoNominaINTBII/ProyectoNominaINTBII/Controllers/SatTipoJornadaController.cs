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
    public class SatTipoJornadaController : ControllerBase
    {
        private readonly ProyDb2bContext _context;  private readonly IMapper _automapper;

        public SatTipoJornadaController(ProyDb2bContext context, IMapper mapper)
        {
             _context = context;            _automapper = mapper;   
        }

        // GET: api/SatTipoJornada
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SatTipoJornadumDTO>>> GetSatTipoJornada()
        {
            return _automapper.Map<List<SatTipoJornadumDTO>>(await _context.SatTipoJornada.ToListAsync());
        }

        // GET: api/SatTipoJornada/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SatTipoJornadumDTO>> GetSatTipoJornadum(int id)
        {
            var satTipoJornadum = _automapper.Map<SatTipoJornadumDTO>(await _context.SatTipoJornada.FindAsync(id));

            if (satTipoJornadum == null)
            {
                return NotFound();
            }

            return satTipoJornadum;
        }

        // PUT: api/SatTipoJornada/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSatTipoJornadum(int id, SatTipoJornadum satTipoJornadum)
        {
            if (id != satTipoJornadum.Id)
            {
                return BadRequest();
            }

            _context.Entry(satTipoJornadum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SatTipoJornadumExists(id))
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

        // POST: api/SatTipoJornada
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SatTipoJornadum>> PostSatTipoJornadum(SatTipoJornadum satTipoJornadum)
        {
            _context.SatTipoJornada.Add(satTipoJornadum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSatTipoJornadum", new { id = satTipoJornadum.Id }, satTipoJornadum);
        }

        // DELETE: api/SatTipoJornada/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSatTipoJornadum(int id)
        {
            var satTipoJornadum = await _context.SatTipoJornada.FindAsync(id);
            if (satTipoJornadum == null)
            {
                return NotFound();
            }

            _context.SatTipoJornada.Remove(satTipoJornadum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SatTipoJornadumExists(int id)
        {
            return _context.SatTipoJornada.Any(e => e.Id == id);
        }
    }
}
