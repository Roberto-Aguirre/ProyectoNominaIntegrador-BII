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
    public class SatTipoRegimenController : ControllerBase
    {
        private readonly ProyDb2bContext _context;  private readonly IMapper _automapper;

        public SatTipoRegimenController(ProyDb2bContext context, IMapper mapper)
        {
             _context = context;            _automapper = mapper;   
        }

        // GET: api/SatTipoRegimen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SatTipoRegimanDTO>>> GetSatTipoRegimen()
        {
            return _automapper.Map<List<SatTipoRegimanDTO>>(await _context.SatTipoRegimen.ToListAsync());
        }

        // GET: api/SatTipoRegimen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SatTipoRegimanDTO>> GetSatTipoRegiman(int id)
        {
            var satTipoRegiman = _automapper.Map<SatTipoRegimanDTO>(await _context.SatTipoRegimen.FindAsync(id));

            if (satTipoRegiman == null)
            {
                return NotFound();
            }

            return satTipoRegiman;
        }

        // PUT: api/SatTipoRegimen/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSatTipoRegiman(int id, SatTipoRegiman satTipoRegiman)
        {
            if (id != satTipoRegiman.Id)
            {
                return BadRequest();
            }

            _context.Entry(satTipoRegiman).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SatTipoRegimanExists(id))
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

        // POST: api/SatTipoRegimen
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SatTipoRegiman>> PostSatTipoRegiman(SatTipoRegiman satTipoRegiman)
        {
            _context.SatTipoRegimen.Add(satTipoRegiman);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSatTipoRegiman", new { id = satTipoRegiman.Id }, satTipoRegiman);
        }

        // DELETE: api/SatTipoRegimen/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSatTipoRegiman(int id)
        {
            var satTipoRegiman = await _context.SatTipoRegimen.FindAsync(id);
            if (satTipoRegiman == null)
            {
                return NotFound();
            }

            _context.SatTipoRegimen.Remove(satTipoRegiman);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SatTipoRegimanExists(int id)
        {
            return _context.SatTipoRegimen.Any(e => e.Id == id);
        }
    }
}
