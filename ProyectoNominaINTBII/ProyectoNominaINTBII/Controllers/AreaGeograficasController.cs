﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoNominaINTBII;

namespace ProyectoNominaINTBII.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaGeograficasController : ControllerBase
    {
        private readonly Prueba3Context _context;

        public AreaGeograficasController(Prueba3Context context)
        {
            _context = context;
        }

        // GET: api/AreaGeograficas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AreaGeografica>>> GetAreaGeograficas()
        {
            //var areaGeograficas = _context.AreaGeograficas.Where(area=>area.Id || area.)
            return await _context.AreaGeograficas.ToListAsync();
        }

        // GET: api/AreaGeograficas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AreaGeografica>> GetAreaGeografica(int id)
        {
            var areaGeografica = await _context.AreaGeograficas.FindAsync(id);

            if (areaGeografica == null)
            {
                return NotFound();
            }

            return areaGeografica;
        }

        // PUT: api/AreaGeograficas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAreaGeografica(int id, AreaGeografica areaGeografica)
        {
            if (id != areaGeografica.Id)
            {
                return BadRequest();
            }

            _context.Entry(areaGeografica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AreaGeograficaExists(id))
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

        // POST: api/AreaGeograficas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AreaGeografica>> PostAreaGeografica(AreaGeografica areaGeografica)
        {
            _context.AreaGeograficas.Add(areaGeografica);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAreaGeografica", new { id = areaGeografica.Id }, areaGeografica);
        }

        // DELETE: api/AreaGeograficas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAreaGeografica(int id)
        {
            var areaGeografica = await _context.AreaGeograficas.FindAsync(id);
            if (areaGeografica == null)
            {
                return NotFound();
            }

            _context.AreaGeograficas.Remove(areaGeografica);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AreaGeograficaExists(int id)
        {
            return _context.AreaGeograficas.Any(e => e.Id == id);
        }
    }
}