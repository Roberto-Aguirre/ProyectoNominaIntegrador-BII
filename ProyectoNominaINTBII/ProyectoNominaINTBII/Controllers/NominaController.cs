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
    public class NominaController : Controller
    {
        private readonly ProyDb2bContext _context;

        public NominaController(ProyDb2bContext context)
        {
            _context = context;
        }

        // GET: Nomina
        public async Task<IActionResult> Index()
        {
            var proyDb2bContext = _context.Nominas.Include(n => n.Empresa).Include(n => n.Periodo).Include(n => n.SatPeriocidadPago).Include(n => n.SatTipoContrato);
            return View(await proyDb2bContext.ToListAsync());
        }

        // GET: Nomina/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nomina = await _context.Nominas
                .Include(n => n.Empresa)
                .Include(n => n.Periodo)
                .Include(n => n.SatPeriocidadPago)
                .Include(n => n.SatTipoContrato)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nomina == null)
            {
                return NotFound();
            }

            return View(nomina);
        }

        // GET: Nomina/Create
        public IActionResult Create()
        {
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Nombre");
            ViewData["PeriodoId"] = new SelectList(_context.Periodos, "Id", "Descripcion");
            ViewData["SatPeriocidadPagoId"] = new SelectList(_context.SatPeriocidadPagos, "Id", "DescripcionSat");
            ViewData["SatTipoContratoId"] = new SelectList(_context.SatTipoContratos, "Id", "Descripcion");
            return View();
        }

        // POST: Nomina/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmpresaId,Ejercicio,FechaPago,SatPeriocidadPagoId,PeriodoId,SatTipoContratoId,NominaExtraordinariaId,ConceptoNomina,ConceptoTimbrado,TotalTrabajadores,TotalPercepciones,TotalDeducciones,Extraordinaria,Generada,Autorizada,Timbrada,Cerrada,Estatus")] Nomina nomina)
        {
            
            Periodo periodo = await _context.Periodos.FindAsync(nomina.PeriodoId);
            nomina.FechaInicial = periodo.FechaInicial;
            nomina.FechaFinal = periodo.FechaFinal;
            nomina.Ejercicio = DateTime.UtcNow.Year;
            
            _context.Add(nomina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Nombre", nomina.EmpresaId);
            //ViewData["PeriodoId"] = new SelectList(_context.Periodos, "Id", "Descripcion", nomina.PeriodoId);
            //ViewData["SatPeriocidadPagoId"] = new SelectList(_context.SatPeriocidadPagos, "Id", "DescripcionSat", nomina.SatPeriocidadPagoId);
            //ViewData["SatTipoContratoId"] = new SelectList(_context.SatTipoContratos, "Id", "Descripcion", nomina.SatTipoContratoId);
            //return View(nomina);
        }

        // GET: Nomina/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nomina = await _context.Nominas.FindAsync(id);
            if (nomina == null)
            {
                return NotFound();
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Nombre", nomina.EmpresaId);
            ViewData["PeriodoId"] = new SelectList(_context.Periodos, "Id", "Descripcion", nomina.PeriodoId);
            ViewData["SatPeriocidadPagoId"] = new SelectList(_context.SatPeriocidadPagos, "Id", "DescripcionSat", nomina.SatPeriocidadPagoId);
            ViewData["SatTipoContratoId"] = new SelectList(_context.SatTipoContratos, "Id", "Descripcion", nomina.SatTipoContratoId);
            return View(nomina);
        }

        // POST: Nomina/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmpresaId,Ejercicio,FechaInicial,FechaFinal,FechaPago,SatPeriocidadPagoId,PeriodoId,SatTipoContratoId,NominaExtraordinariaId,ConceptoNomina,ConceptoTimbrado,TotalTrabajadores,TotalPercepciones,TotalDeducciones,Extraordinaria,Generada,Autorizada,Timbrada,Cerrada,Estatus")] Nomina nomina)
        {
            if (id != nomina.Id)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(nomina);
                    await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NominaExists(nomina.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                
            }
            //ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Nombre", nomina.EmpresaId);
            //ViewData["PeriodoId"] = new SelectList(_context.Periodos, "Id", "Descripcion", nomina.PeriodoId);
            //ViewData["SatPeriocidadPagoId"] = new SelectList(_context.SatPeriocidadPagos, "Id", "DescripcionSat", nomina.SatPeriocidadPagoId);
            //ViewData["SatTipoContratoId"] = new SelectList(_context.SatTipoContratos, "Id", "Id", nomina.SatTipoContratoId);
            //return View(nomina);
        }

        // GET: Nomina/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nomina = await _context.Nominas
                .Include(n => n.Empresa)
                .Include(n => n.Periodo)
                .Include(n => n.SatPeriocidadPago)
                .Include(n => n.SatTipoContrato)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nomina == null)
            {
                return NotFound();
            }

            return View(nomina);
        }

        // POST: Nomina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nomina = await _context.Nominas.FindAsync(id);
            if (nomina != null)
            {
                _context.Nominas.Remove(nomina);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NominaExists(int id)
        {
            return _context.Nominas.Any(e => e.Id == id);
        }
    }
}
