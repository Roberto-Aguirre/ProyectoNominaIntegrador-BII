﻿using System;
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
    public class EstadoCivilController : ControllerBase
    {
        private readonly ProyDb2bContext _context;  private readonly IMapper _automapper;

        public EstadoCivilController(ProyDb2bContext context, IMapper mapper)
        {
             _context = context;            _automapper = mapper;   
        }

        // GET: api/EstadoCivil
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoCivilDTO>>> GetEstadoCivils()
        {
            return _automapper.Map<List<EstadoCivilDTO>>(await _context.EstadoCivils.ToListAsync());
        }

        // GET: api/EstadoCivil/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoCivilDTO>> GetEstadoCivil(int id)
        {
            var estadoCivil = _automapper.Map<EstadoCivilDTO>(await _context.EstadoCivils.FindAsync(id));

            if (estadoCivil == null)
            {
                return NotFound();
            }

            return estadoCivil;
        }

        // PUT: api/EstadoCivil/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoCivil(int id, EstadoCivil estadoCivil)
        {
            if (id != estadoCivil.Id)
            {
                return BadRequest();
            }

            _context.Entry(estadoCivil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoCivilExists(id))
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

        // POST: api/EstadoCivil
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstadoCivil>> PostEstadoCivil(EstadoCivil estadoCivil)
        {
            _context.EstadoCivils.Add(estadoCivil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoCivil", new { id = estadoCivil.Id }, estadoCivil);
        }

        // DELETE: api/EstadoCivil/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoCivil(int id)
        {
            var estadoCivil = await _context.EstadoCivils.FindAsync(id);
            if (estadoCivil == null)
            {
                return NotFound();
            }

            _context.EstadoCivils.Remove(estadoCivil);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoCivilExists(int id)
        {
            return _context.EstadoCivils.Any(e => e.Id == id);
        }
    }
}
