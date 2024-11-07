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
    public class SatMonedaController : ControllerBase
    {
        private readonly Prueba3Context _context;  private readonly IMapper _automapper;

        public SatMonedaController(Prueba3Context context, IMapper mapper)
        {
             _context = context;            _automapper = mapper;   
        }

        // GET: api/SatMoneda
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SatMonedumDTO>>> GetSatMoneda()
        {
            return _automapper.Map<List<SatMonedumDTO>>(await _context.SatMoneda.ToListAsync());
        }

        // GET: api/SatMoneda/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SatMonedumDTO>> GetSatMonedum(int id)
        {
            var satMonedum = _automapper.Map<SatMonedumDTO>(await _context.SatMoneda.FindAsync(id));

            if (satMonedum == null)
            {
                return NotFound();
            }

            return satMonedum;
        }

        // PUT: api/SatMoneda/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSatMonedum(int id, SatMonedum satMonedum)
        {
            if (id != satMonedum.Id)
            {
                return BadRequest();
            }

            _context.Entry(satMonedum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SatMonedumExists(id))
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

        // POST: api/SatMoneda
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SatMonedum>> PostSatMonedum(SatMonedum satMonedum)
        {
            _context.SatMoneda.Add(satMonedum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSatMonedum", new { id = satMonedum.Id }, satMonedum);
        }

        // DELETE: api/SatMoneda/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSatMonedum(int id)
        {
            var satMonedum = await _context.SatMoneda.FindAsync(id);
            if (satMonedum == null)
            {
                return NotFound();
            }

            _context.SatMoneda.Remove(satMonedum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SatMonedumExists(int id)
        {
            return _context.SatMoneda.Any(e => e.Id == id);
        }
    }
}
