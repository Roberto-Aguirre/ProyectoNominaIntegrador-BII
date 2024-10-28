using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoNominaINTBII.Data;
using ProyectoNominaINTBII.Models;

namespace ProyectoNominaINTBII.Controllers
{
    public class BaseCotizacionsController : Controller
    {
        private readonly ProyectoNominaINTBIIContext _context;

        public BaseCotizacionsController(ProyectoNominaINTBIIContext context)
        {
            _context = context;
        }

        // GET: BaseCotizacions
        public async Task<IActionResult> Index()
        {
            return View(await _context.BaseCotizacion.ToListAsync());
        }

        // GET: BaseCotizacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseCotizacion = await _context.BaseCotizacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baseCotizacion == null)
            {
                return NotFound();
            }

            return View(baseCotizacion);
        }

        // GET: BaseCotizacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BaseCotizacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Estatus")] BaseCotizacion baseCotizacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baseCotizacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baseCotizacion);
        }

        // GET: BaseCotizacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseCotizacion = await _context.BaseCotizacion.FindAsync(id);
            if (baseCotizacion == null)
            {
                return NotFound();
            }
            return View(baseCotizacion);
        }

        // POST: BaseCotizacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Estatus")] BaseCotizacion baseCotizacion)
        {
            if (id != baseCotizacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baseCotizacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaseCotizacionExists(baseCotizacion.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(baseCotizacion);
        }

        // GET: BaseCotizacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseCotizacion = await _context.BaseCotizacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baseCotizacion == null)
            {
                return NotFound();
            }

            return View(baseCotizacion);
        }

        // POST: BaseCotizacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var baseCotizacion = await _context.BaseCotizacion.FindAsync(id);
            if (baseCotizacion != null)
            {
                _context.BaseCotizacion.Remove(baseCotizacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaseCotizacionExists(int id)
        {
            return _context.BaseCotizacion.Any(e => e.Id == id);
        }
    }
}
