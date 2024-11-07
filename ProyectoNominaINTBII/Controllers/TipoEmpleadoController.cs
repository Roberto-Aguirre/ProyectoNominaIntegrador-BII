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
    public class TipoEmpleadoController : ControllerBase
    {
        private readonly Prueba3Context _context;
        private readonly IMapper _automapper;
        public TipoEmpleadoController(Prueba3Context context, IMapper mapper)
        {
             _context = context;            _automapper = mapper;   
        }

        // GET: api/TipoEmpleado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoEmpleadoDTO>>> GetTipoEmpleados()
        {
            return _automapper.Map<List<TipoEmpleadoDTO>>(await _context.TipoEmpleados.ToListAsync());
        }

        // GET: api/TipoEmpleado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoEmpleadoDTO>> GetTipoEmpleado(int id)
        {
            var tipoEmpleado = _automapper.Map<TipoEmpleadoDTO>(await _context.TipoEmpleados.FindAsync(id));

            if (tipoEmpleado == null)
            {
                return NotFound();
            }

            return tipoEmpleado;
        }

        // PUT: api/TipoEmpleado/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoEmpleado(int id, TipoEmpleado tipoEmpleado)
        {
            if (id != tipoEmpleado.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoEmpleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoEmpleadoExists(id))
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

        // POST: api/TipoEmpleado
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoEmpleado>> PostTipoEmpleado(TipoEmpleado tipoEmpleado)
        {
            _context.TipoEmpleados.Add(tipoEmpleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoEmpleado", new { id = tipoEmpleado.Id }, tipoEmpleado);
        }

        // DELETE: api/TipoEmpleado/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoEmpleado(int id)
        {
            var tipoEmpleado = await _context.TipoEmpleados.FindAsync(id);
            if (tipoEmpleado == null)
            {
                return NotFound();
            }

            _context.TipoEmpleados.Remove(tipoEmpleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoEmpleadoExists(int id)
        {
            return _context.TipoEmpleados.Any(e => e.Id == id);
        }
    }
}
