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
    public class AreaGeograficasController : Controller
    {
        private readonly ProyDb2bContext _context;

        public AreaGeograficasController(ProyDb2bContext context)
        {
            _context = context;
        }

        // GET: AreaGeograficas
        public async Task<IActionResult> Index()
        {
            return View(await _context.AreaGeograficas.ToListAsync());
        }

        // GET: AreaGeograficas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areaGeografica = await _context.AreaGeograficas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (areaGeografica == null)
            {
                return NotFound();
            }

            return View(areaGeografica);
        }

        // GET: AreaGeograficas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AreaGeograficas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Clave,Descripcion,Estatus")] AreaGeografica areaGeografica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(areaGeografica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(areaGeografica);
        }

        // GET: AreaGeograficas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areaGeografica = await _context.AreaGeograficas.FindAsync(id);
            if (areaGeografica == null)
            {
                return NotFound();
            }
            return View(areaGeografica);
        }

        // POST: AreaGeograficas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Clave,Descripcion,Estatus")] AreaGeografica areaGeografica)
        {
            if (id != areaGeografica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(areaGeografica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreaGeograficaExists(areaGeografica.Id))
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
            return View(areaGeografica);
        }

        // GET: AreaGeograficas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areaGeografica = await _context.AreaGeograficas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (areaGeografica == null)
            {
                return NotFound();
            }

            return View(areaGeografica);
        }

        // POST: AreaGeograficas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var areaGeografica = await _context.AreaGeograficas.FindAsync(id);
            if (areaGeografica != null)
            {
                _context.AreaGeograficas.Remove(areaGeografica);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AreaGeograficaExists(int id)
        {
            return _context.AreaGeograficas.Any(e => e.Id == id);
        }
    }
}
