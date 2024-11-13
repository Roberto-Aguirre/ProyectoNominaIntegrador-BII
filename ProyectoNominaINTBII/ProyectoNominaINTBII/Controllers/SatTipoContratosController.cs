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
    public class SatTipoContratosController : ControllerBase
    {
        private readonly ProyDb2bContext _context;  private readonly IMapper _automapper;

        public SatTipoContratosController(ProyDb2bContext context, IMapper mapper)
        {
             _context = context;            _automapper = mapper;   
        }

        // GET: api/SatTipoContratos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SatTipoContratoDTO>>> GetSatTipoContratos()
        {
            return _automapper.Map<List<SatTipoContratoDTO>>(await _context.SatTipoContratos.ToListAsync());
        }

        // GET: api/SatTipoContratos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SatTipoContratoDTO>> GetSatTipoContrato(int id)
        {
            var satTipoContrato = _automapper.Map<SatTipoContratoDTO>(await _context.SatTipoContratos.FindAsync(id));

            if (satTipoContrato == null)
            {
                return NotFound();
            }

            return satTipoContrato;
        }

        // PUT: api/SatTipoContratos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSatTipoContrato(int id, SatTipoContrato satTipoContrato)
        {
            if (id != satTipoContrato.Id)
            {
                return BadRequest();
            }

            _context.Entry(satTipoContrato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SatTipoContratoExists(id))
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

        // POST: api/SatTipoContratos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SatTipoContrato>> PostSatTipoContrato(SatTipoContrato satTipoContrato)
        {
            _context.SatTipoContratos.Add(satTipoContrato);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSatTipoContrato", new { id = satTipoContrato.Id }, satTipoContrato);
        }

        // DELETE: api/SatTipoContratos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSatTipoContrato(int id)
        {
            var satTipoContrato = await _context.SatTipoContratos.FindAsync(id);
            if (satTipoContrato == null)
            {
                return NotFound();
            }

            _context.SatTipoContratos.Remove(satTipoContrato);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SatTipoContratoExists(int id)
        {
            return _context.SatTipoContratos.Any(e => e.Id == id);
        }
    }
}
