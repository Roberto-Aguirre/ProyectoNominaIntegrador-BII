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
    public class SatOrigenRecursosController : ControllerBase
    {
        private readonly ProyDb2bContext _context;  private readonly IMapper _automapper;

        public SatOrigenRecursosController(ProyDb2bContext context, IMapper mapper)
        {
             _context = context;            _automapper = mapper;   
        }

        // GET: api/SatOrigenRecursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SatOrigenRecursoDTO>>> GetSatOrigenRecursos()
        {
            return _automapper.Map<List<SatOrigenRecursoDTO>>(await _context.SatOrigenRecursos.ToListAsync());
        }

        // GET: api/SatOrigenRecursos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SatOrigenRecursoDTO>> GetSatOrigenRecurso(int id)
        {
            var satOrigenRecurso = _automapper.Map<SatOrigenRecursoDTO>(await _context.SatOrigenRecursos.FindAsync(id));

            if (satOrigenRecurso == null)
            {
                return NotFound();
            }

            return satOrigenRecurso;
        }

        // PUT: api/SatOrigenRecursos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSatOrigenRecurso(int id, SatOrigenRecurso satOrigenRecurso)
        {
            if (id != satOrigenRecurso.Id)
            {
                return BadRequest();
            }

            _context.Entry(satOrigenRecurso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SatOrigenRecursoExists(id))
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

        // POST: api/SatOrigenRecursos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SatOrigenRecurso>> PostSatOrigenRecurso(SatOrigenRecurso satOrigenRecurso)
        {
            _context.SatOrigenRecursos.Add(satOrigenRecurso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSatOrigenRecurso", new { id = satOrigenRecurso.Id }, satOrigenRecurso);
        }

        // DELETE: api/SatOrigenRecursos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSatOrigenRecurso(int id)
        {
            var satOrigenRecurso = await _context.SatOrigenRecursos.FindAsync(id);
            if (satOrigenRecurso == null)
            {
                return NotFound();
            }

            _context.SatOrigenRecursos.Remove(satOrigenRecurso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SatOrigenRecursoExists(int id)
        {
            return _context.SatOrigenRecursos.Any(e => e.Id == id);
        }
    }
}
