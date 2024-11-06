using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoNominaINTBII.ProyectoDbContext;


using ProyectoNominaINTBII.Models;

namespace ProyectoNominaINTBII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatMonedumController : ControllerBase
    {
        private readonly ProyBd2bContext _context;

        public SatMonedumController(ProyBd2bContext context)
        {
            _context = context;
        }

        // GET: api/SatMonedum
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SatMonedum>>> GetSatMonedum()
        {
            return await _context.SatMoneda.ToListAsync();
        }

        // GET: api/SatMonedum/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SatMonedum>> GetSatMonedum(int id)
        {
            var SatMonedum = await _context.SatMoneda.FindAsync(id);

            if (SatMonedum == null)
            {
                return NotFound();
            }

            return SatMonedum;
        }

        // PUT: api/SatMonedum/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSatMonedum(int id, SatMonedum SatMonedum)
        {
            if (id != SatMonedum.Id)
            {
                return BadRequest();
            }

            _context.Entry(SatMonedum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SatMonedaExists(id))
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

        // POST: api/SatMonedum
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SatMonedum>> PostSatMoneda(SatMonedum satMoneda)
        {
            _context.SatMoneda.Add(satMoneda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSatMoneda", new { id = satMoneda.Id }, satMoneda);
        }

        // DELETE: api/SatMonedum/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSatMoneda(int id)
        {
            var satMoneda = await _context.SatMoneda.FindAsync(id);
            if (satMoneda == null)
            {
                return NotFound();
            }

            _context.SatMoneda.Remove(satMoneda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SatMonedaExists(int id)
        {
            return _context.SatMoneda.Any(e => e.Id == id);
        }
    }
}
