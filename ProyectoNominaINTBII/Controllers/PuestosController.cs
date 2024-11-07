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
    public class PuestosController : ControllerBase
    {
        private readonly Prueba3Context _context;  private readonly IMapper _automapper;

        public PuestosController(Prueba3Context context, IMapper mapper)
        {
             _context = context;            _automapper = mapper;   
        }

        // GET: api/Puestos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PuestoDTO>>> GetPuestos()
        {
            return _automapper.Map<List<PuestoDTO>>(await _context.Puestos.ToListAsync());
        }

        // GET: api/Puestos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PuestoDTO>> GetPuesto(int id)
        {
            var puesto = _automapper.Map<PuestoDTO>(await _context.Puestos.FindAsync(id));

            if (puesto == null)
            {
                return NotFound();
            }

            return puesto;
        }

        // PUT: api/Puestos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPuesto(int id, Puesto puesto)
        {
            if (id != puesto.Id)
            {
                return BadRequest();
            }

            _context.Entry(puesto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuestoExists(id))
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

        // POST: api/Puestos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Puesto>> PostPuesto(Puesto puesto)
        {
            _context.Puestos.Add(puesto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPuesto", new { id = puesto.Id }, puesto);
        }

        // DELETE: api/Puestos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePuesto(int id)
        {
            var puesto = await _context.Puestos.FindAsync(id);
            if (puesto == null)
            {
                return NotFound();
            }

            _context.Puestos.Remove(puesto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PuestoExists(int id)
        {
            return _context.Puestos.Any(e => e.Id == id);
        }
    }
}
