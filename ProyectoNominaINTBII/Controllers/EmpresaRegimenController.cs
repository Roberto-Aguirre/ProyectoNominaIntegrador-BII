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

namespace ProyectoNominaINTBII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaRegimenController : ControllerBase
    {
        private readonly Prueba3Context _context;
        private readonly IMapper _automapper;

        public EmpresaRegimenController(Prueba3Context context, IMapper mapper)
        {
            _automapper = mapper;
            _context = context;
        }

        // GET: api/EmpresaRegimen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaRegPatDTO>>> GetEmpresaRegPats()
        {
            return _automapper.Map<List<EmpresaRegPatDTO>>(await _context.EmpresaRegPats.ToListAsync());
        }

        // GET: api/EmpresaRegimen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpresaRegPatDTO>> GetEmpresaRegPat(int id)
        {
            var empresaRegPat = _automapper.Map<EmpresaRegPatDTO>(await _context.EmpresaRegPats.FindAsync(id));

            if (empresaRegPat == null)
            {
                return NotFound();
            }

            return empresaRegPat;
        }

        // PUT: api/EmpresaRegimen/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpresaRegPat(int id, EmpresaRegPat empresaRegPat)
        {
            if (id != empresaRegPat.Id)
            {
                return BadRequest();
            }

            _context.Entry(empresaRegPat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresaRegPatExists(id))
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

        // POST: api/EmpresaRegimen
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmpresaRegPat>> PostEmpresaRegPat(EmpresaRegPat empresaRegPat)
        {
            _context.EmpresaRegPats.Add(empresaRegPat);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmpresaRegPatExists(empresaRegPat.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmpresaRegPat", new { id = empresaRegPat.Id }, empresaRegPat);
        }

        // DELETE: api/EmpresaRegimen/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresaRegPat(int id)
        {
            var empresaRegPat = await _context.EmpresaRegPats.FindAsync(id);
            if (empresaRegPat == null)
            {
                return NotFound();
            }

            _context.EmpresaRegPats.Remove(empresaRegPat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpresaRegPatExists(int id)
        {
            return _context.EmpresaRegPats.Any(e => e.Id == id);
        }
    }
}
