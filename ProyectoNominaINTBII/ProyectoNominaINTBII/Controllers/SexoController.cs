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
    public class SexoController : ControllerBase
    {
        private readonly ProyDb2bContext _context;  private readonly IMapper _automapper;

        public SexoController(ProyDb2bContext context, IMapper mapper)
        {
             _context = context;            _automapper = mapper;   
        }

        // GET: api/Sexo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SexoDTO>>> GetSexos()
        {
            return _automapper.Map<List<SexoDTO>>(await _context.Sexos.ToListAsync());
        }

        // GET: api/Sexo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SexoDTO>> GetSexo(int id)
        {
            var sexo = _automapper.Map<SexoDTO>(await _context.Sexos.FindAsync(id));

            if (sexo == null)
            {
                return NotFound();
            }

            return sexo;
        }

        // PUT: api/Sexo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSexo(int id, Sexo sexo)
        {
            if (id != sexo.Id)
            {
                return BadRequest();
            }

            _context.Entry(sexo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SexoExists(id))
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

        // POST: api/Sexo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sexo>> PostSexo(Sexo sexo)
        {
            _context.Sexos.Add(sexo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSexo", new { id = sexo.Id }, sexo);
        }

        // DELETE: api/Sexo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSexo(int id)
        {
            var sexo = await _context.Sexos.FindAsync(id);
            if (sexo == null)
            {
                return NotFound();
            }

            _context.Sexos.Remove(sexo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SexoExists(int id)
        {
            return _context.Sexos.Any(e => e.Id == id);
        }
    }
}
