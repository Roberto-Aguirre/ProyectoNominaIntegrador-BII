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
    public class SatRegimenFiscalController : ControllerBase
    {
        private readonly Prueba3Context _context;  private readonly IMapper _automapper;

        public SatRegimenFiscalController(Prueba3Context context, IMapper mapper)
        {
             _context = context;            _automapper = mapper;   
        }

        // GET: api/SatRegimenFiscal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SatRegimenFiscalDTO>>> GetSatRegimenFiscals()
        {
            return _automapper.Map<List<SatRegimenFiscalDTO>>(await _context.SatRegimenFiscals.ToListAsync());
        }

        // GET: api/SatRegimenFiscal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SatRegimenFiscalDTO>> GetSatRegimenFiscal(int id)
        {
            var satRegimenFiscal = _automapper.Map<SatRegimenFiscalDTO>(await _context.SatRegimenFiscals.FindAsync(id));

            if (satRegimenFiscal == null)
            {
                return NotFound();
            }

            return satRegimenFiscal;
        }

        // PUT: api/SatRegimenFiscal/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSatRegimenFiscal(int id, SatRegimenFiscal satRegimenFiscal)
        {
            if (id != satRegimenFiscal.Id)
            {
                return BadRequest();
            }

            _context.Entry(satRegimenFiscal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SatRegimenFiscalExists(id))
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

        // POST: api/SatRegimenFiscal
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SatRegimenFiscal>> PostSatRegimenFiscal(SatRegimenFiscal satRegimenFiscal)
        {
            _context.SatRegimenFiscals.Add(satRegimenFiscal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSatRegimenFiscal", new { id = satRegimenFiscal.Id }, satRegimenFiscal);
        }

        // DELETE: api/SatRegimenFiscal/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSatRegimenFiscal(int id)
        {
            var satRegimenFiscal = await _context.SatRegimenFiscals.FindAsync(id);
            if (satRegimenFiscal == null)
            {
                return NotFound();
            }

            _context.SatRegimenFiscals.Remove(satRegimenFiscal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SatRegimenFiscalExists(int id)
        {
            return _context.SatRegimenFiscals.Any(e => e.Id == id);
        }
    }
}
