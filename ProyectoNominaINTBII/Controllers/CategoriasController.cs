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
using AutoMapper;

namespace ProyectoNominaINTBII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ProyDb2bContext _context;  private readonly IMapper _automapper;
       

        public CategoriasController(ProyDb2bContext context, IMapper mapper)
        {
            _automapper = mapper;   
            _context = context;
        }

        // GET: api/Categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriumDTO>>> GetCategoria()
        {
            return _automapper.Map<List<CategoriumDTO>>(await _context.Categoria.ToListAsync());
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriumDTO>> GetCategorium(int id)
        {
            var categorium = _automapper.Map<CategoriumDTO>(await _context.Categoria.FindAsync(id));

            if (categorium == null)
            {
                return NotFound();
            }

            return categorium;
        }

        // PUT: api/Categorias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorium(int id, Categorium categorium)
        {
            if (id != categorium.Id)
            {
                return BadRequest();
            }

            _context.Entry(categorium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriumExists(id))
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

        // POST: api/Categorias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Categorium>> PostCategorium(Categorium categorium)
        {
            _context.Categoria.Add(categorium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategorium", new { id = categorium.Id }, categorium);
        }

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategorium(int id)
        {
            var categorium = await _context.Categoria.FindAsync(id);
            if (categorium == null)
            {
                return NotFound();
            }

            _context.Categoria.Remove(categorium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriumExists(int id)
        {
            return _context.Categoria.Any(e => e.Id == id);
        }
    }
}
