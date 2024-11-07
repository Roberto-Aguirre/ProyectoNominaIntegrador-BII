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
    public class MotivoNoTimbrarController : ControllerBase
    {
        private readonly Prueba3Context _context;  private readonly IMapper _automapper;

        public MotivoNoTimbrarController(Prueba3Context context, IMapper mapper)
        {
             _context = context;            _automapper = mapper;   
        }

        // GET: api/MotivoNoTimbrar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotivoNoTimbrarDTO>>> GetMotivoNoTimbrars()
        {
            return  _automapper.Map<List<MotivoNoTimbrarDTO>>(await _context.MotivoNoTimbrars.ToListAsync());
        }

        // GET: api/MotivoNoTimbrar/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MotivoNoTimbrarDTO>> GetMotivoNoTimbrar(int id)
        {
            var motivoNoTimbrar = _automapper.Map<MotivoNoTimbrarDTO>(await _context.MotivoNoTimbrars.FindAsync(id));

            if (motivoNoTimbrar == null)
            {
                return NotFound();
            }

            return motivoNoTimbrar;
        }

        // PUT: api/MotivoNoTimbrar/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMotivoNoTimbrar(int id, MotivoNoTimbrar motivoNoTimbrar)
        {
            if (id != motivoNoTimbrar.Id)
            {
                return BadRequest();
            }

            _context.Entry(motivoNoTimbrar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotivoNoTimbrarExists(id))
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

        // POST: api/MotivoNoTimbrar
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MotivoNoTimbrar>> PostMotivoNoTimbrar(MotivoNoTimbrar motivoNoTimbrar)
        {
            _context.MotivoNoTimbrars.Add(motivoNoTimbrar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMotivoNoTimbrar", new { id = motivoNoTimbrar.Id }, motivoNoTimbrar);
        }

        // DELETE: api/MotivoNoTimbrar/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMotivoNoTimbrar(int id)
        {
            var motivoNoTimbrar = await _context.MotivoNoTimbrars.FindAsync(id);
            if (motivoNoTimbrar == null)
            {
                return NotFound();
            }

            _context.MotivoNoTimbrars.Remove(motivoNoTimbrar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MotivoNoTimbrarExists(int id)
        {
            return _context.MotivoNoTimbrars.Any(e => e.Id == id);
        }
    }
}
