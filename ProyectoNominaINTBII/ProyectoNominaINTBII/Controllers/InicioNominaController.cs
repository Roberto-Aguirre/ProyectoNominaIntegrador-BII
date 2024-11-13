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
    public class InicioNominaController : ControllerBase
    {
        private readonly ProyDb2bContext _context;

        public InicioNominaController(ProyDb2bContext context)
        {
            _context = context;
        }

        // GET: api/InicioNomina
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InicioNomina>>> GetInicioNominas()
        {
            return await _context.InicioNominas.ToListAsync();
        }

        // GET: api/InicioNomina/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InicioNomina>> GetInicioNomina(int id)
        {
            var inicioNomina = await _context.InicioNominas.FindAsync(id);

            if (inicioNomina == null)
            {
                return NotFound();
            }

            return inicioNomina;
        }

        // PUT: api/InicioNomina/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInicioNomina(int id, InicioNomina inicioNomina)
        {
            if (id != inicioNomina.Id)
            {
                return BadRequest();
            }

            _context.Entry(inicioNomina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InicioNominaExists(id))
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

        // POST: api/InicioNomina
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InicioNomina>> PostInicioNomina(InicioNomina inicioNomina)
        {
            _context.InicioNominas.Add(inicioNomina);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInicioNomina", new { id = inicioNomina.Id }, inicioNomina);
        }

        // DELETE: api/InicioNomina/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInicioNomina(int id)
        {
            var inicioNomina = await _context.InicioNominas.FindAsync(id);
            if (inicioNomina == null)
            {
                return NotFound();
            }

            _context.InicioNominas.Remove(inicioNomina);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InicioNominaExists(int id)
        {
            return _context.InicioNominas.Any(e => e.Id == id);
        }
    }
}
