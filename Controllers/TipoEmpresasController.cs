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
    public class TipoEmpresasController : ControllerBase
    {
        private readonly ProyBd2bContext _context;

        public TipoEmpresasController(ProyBd2bContext context)
        {
            _context = context;
        }

        // GET: api/TipoEmpresas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoEmpresa>>> GetTipoEmpresas()
        {
            return await _context.TipoEmpresas.ToListAsync();
        }

        // GET: api/TipoEmpresas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoEmpresa>> GetTipoEmpresa(int id)
        {
            var tipoEmpresa = await _context.TipoEmpresas.FindAsync(id);

            if (tipoEmpresa == null)
            {
                return NotFound();
            }

            return tipoEmpresa;
        }

        // PUT: api/TipoEmpresas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoEmpresa(int id, TipoEmpresa tipoEmpresa)
        {
            if (id != tipoEmpresa.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoEmpresa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoEmpresaExists(id))
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

        // POST: api/TipoEmpresas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoEmpresa>> PostTipoEmpresa(TipoEmpresa tipoEmpresa)
        {
            _context.TipoEmpresas.Add(tipoEmpresa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoEmpresa", new { id = tipoEmpresa.Id }, tipoEmpresa);
        }

        // DELETE: api/TipoEmpresas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoEmpresa(int id)
        {
            var tipoEmpresa = await _context.TipoEmpresas.FindAsync(id);
            if (tipoEmpresa == null)
            {
                return NotFound();
            }

            _context.TipoEmpresas.Remove(tipoEmpresa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoEmpresaExists(int id)
        {
            return _context.TipoEmpresas.Any(e => e.Id == id);
        }
    }
}
