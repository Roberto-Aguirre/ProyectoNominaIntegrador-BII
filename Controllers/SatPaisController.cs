﻿using System;
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
    public class SatPaisController : ControllerBase
    {
        private readonly ProyBd2bContext _context;

        public SatPaisController(ProyBd2bContext context)
        {
            _context = context;
        }

        // GET: api/SatPai
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SatPai>>> GetSatPais()
        {
            return await _context.SatPais.ToListAsync();
        }

        // GET: api/SatPai/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SatPai>> GetSatPais(int id)
        {
            var satPais = await _context.SatPais.FindAsync(id);

            if (satPais == null)
            {
                return NotFound();
            }

            return satPais;
        }

        // PUT: api/SatPai/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSatPais(int id, SatPai satPais)
        {
            if (id != satPais.Id)
            {
                return BadRequest();
            }

            _context.Entry(satPais).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SatPaisExists(id))
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

        // POST: api/SatPai
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SatPai>> PostSatPais(SatPai satPais)
        {
            _context.SatPais.Add(satPais);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSatPais", new { id = satPais.Id }, satPais);
        }

        // DELETE: api/SatPai/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSatPais(int id)
        {
            var satPais = await _context.SatPais.FindAsync(id);
            if (satPais == null)
            {
                return NotFound();
            }

            _context.SatPais.Remove(satPais);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SatPaisExists(int id)
        {
            return _context.SatPais.Any(e => e.Id == id);
        }
    }
}
