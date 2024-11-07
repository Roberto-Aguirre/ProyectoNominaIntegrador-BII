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
using AutoMapper;

namespace ProyectoNominaINTBII.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajadoresController : ControllerBase
    {
        private readonly Prueba3Context _context;
        private readonly IMapper _automapper;

        public TrabajadoresController(Prueba3Context context, IMapper mapper)
        {
             _context = context;            
            _automapper = mapper;   
        }

        // GET: api/Trabajadores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrabajadorDTO>>> GetTrabajadors()
        {
            return _automapper.Map<List<TrabajadorDTO>>(await _context.Trabajadors.ToListAsync());
        }

        // GET: api/Trabajadores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrabajadorDTO>> GetTrabajador(int id)
        {
            var trabajador = _automapper.Map<TrabajadorDTO>(await _context.Trabajadors.FindAsync(id));

            if (trabajador == null)
            {
                return NotFound();
            }

            return trabajador;
        }

        // PUT: api/Trabajadores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrabajador(int id, Trabajador trabajador)
        {
            if (id != trabajador.Id)
            {
                return BadRequest();
            }

            _context.Entry(trabajador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrabajadorExists(id))
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

        // POST: api/Trabajadores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trabajador>> PostTrabajador(Trabajador trabajador)
        {
            _context.Trabajadors.Add(trabajador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrabajador", new { id = trabajador.Id }, trabajador);
        }

        // DELETE: api/Trabajadores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrabajador(int id)
        {
            var trabajador = await _context.Trabajadors.FindAsync(id);
            if (trabajador == null)
            {
                return NotFound();
            }

            _context.Trabajadors.Remove(trabajador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrabajadorExists(int id)
        {
            return _context.Trabajadors.Any(e => e.Id == id);
        }
    }
}
