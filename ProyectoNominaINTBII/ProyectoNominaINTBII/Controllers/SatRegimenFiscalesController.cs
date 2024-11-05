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
    public class SatRegimenFiscalesController : ControllerBase
    {
        private readonly ProyBd2bContext _context;

        public SatRegimenFiscalesController(ProyBd2bContext context)
        {
            _context = context;
        }

        // GET: api/SatRegimenFiscales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SatRegimenFiscal>>> GetSatRegimenFiscals()
        {
            return await _context.SatRegimenFiscals.ToListAsync();
        }

        // GET: api/SatRegimenFiscales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SatRegimenFiscal>> GetSatRegimenFiscal(int id)
        {
            var satRegimenFiscal = await _context.SatRegimenFiscals.FindAsync(id);

            if (satRegimenFiscal == null)
            {
                return NotFound();
            }

            return satRegimenFiscal;
        }

        // PUT: api/SatRegimenFiscales/5
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

        // POST: api/SatRegimenFiscales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SatRegimenFiscal>> PostSatRegimenFiscal(SatRegimenFiscal satRegimenFiscal)
        {
            _context.SatRegimenFiscals.Add(satRegimenFiscal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSatRegimenFiscal", new { id = satRegimenFiscal.Id }, satRegimenFiscal);
        }

        // DELETE: api/SatRegimenFiscales/5
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
