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
    public class SatRiesgoPuestoController : ControllerBase
    {
        private readonly ProyDb2bContext _context;  private readonly IMapper _automapper;

        public SatRiesgoPuestoController(ProyDb2bContext context, IMapper mapper)
        {
             _context = context;            _automapper = mapper;   
        }

        // GET: api/SatRiesgoPuesto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SatRiesgoPuestoDTO>>> GetSatRiesgoPuestos()
        {
            return _automapper.Map<List<SatRiesgoPuestoDTO>>(await _context.SatRiesgoPuestos.ToListAsync());
        }

        // GET: api/SatRiesgoPuesto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SatRiesgoPuestoDTO>> GetSatRiesgoPuesto(int id)
        { 

            var satRiesgoPuesto = _automapper.Map<SatRiesgoPuestoDTO>(await _context.SatRiesgoPuestos.FindAsync(id));

            if (satRiesgoPuesto == null)
            {
                return NotFound();
            }

            return satRiesgoPuesto;
        }

        // PUT: api/SatRiesgoPuesto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSatRiesgoPuesto(int id, SatRiesgoPuesto satRiesgoPuesto)
        {
            if (id != satRiesgoPuesto.Id)
            {
                return BadRequest();
            }

            _context.Entry(satRiesgoPuesto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SatRiesgoPuestoExists(id))
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

        // POST: api/SatRiesgoPuesto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SatRiesgoPuesto>> PostSatRiesgoPuesto(SatRiesgoPuesto satRiesgoPuesto)
        {
            _context.SatRiesgoPuestos.Add(satRiesgoPuesto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSatRiesgoPuesto", new { id = satRiesgoPuesto.Id }, satRiesgoPuesto);
        }

        // DELETE: api/SatRiesgoPuesto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSatRiesgoPuesto(int id)
        {
            var satRiesgoPuesto = await _context.SatRiesgoPuestos.FindAsync(id);
            if (satRiesgoPuesto == null)
            {
                return NotFound();
            }

            _context.SatRiesgoPuestos.Remove(satRiesgoPuesto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SatRiesgoPuestoExists(int id)
        {
            return _context.SatRiesgoPuestos.Any(e => e.Id == id);
        }
    }
}
