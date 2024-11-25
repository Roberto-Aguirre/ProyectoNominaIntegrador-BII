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
    public class EmpresasController : Controller
    {
        private readonly ProyDb2bContext _context;

        public EmpresasController(ProyDb2bContext context)
        {
            _context = context;
        }

        // GET: Empresas
        public async Task<IActionResult> Index()
        {
            var proyDb2bContext = _context.Empresas.Include(e => e.Estado).Include(e => e.Moneda).Include(e => e.Municipio).Include(e => e.Pais).Include(e => e.RegimenFiscal).Include(e => e.TipoConstitucion).Include(e => e.TipoEmpresa).Include(e => e.TipoHora);
            return View(await proyDb2bContext.ToListAsync());
        }

        // GET: Empresas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas
                .Include(e => e.Estado)
                .Include(e => e.Moneda)
                .Include(e => e.Municipio)
                .Include(e => e.Pais)
                .Include(e => e.RegimenFiscal)
                .Include(e => e.TipoConstitucion)
                .Include(e => e.TipoEmpresa)
                .Include(e => e.TipoHora)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // GET: Empresas/Create
        public IActionResult Create()
        {
            ViewData["EstadoId"] = new SelectList(_context.SatEstados, "Id", "Id");
            ViewData["MonedaId"] = new SelectList(_context.SatMoneda, "Id", "Id");
            ViewData["MunicipioId"] = new SelectList(_context.SatMunicipios, "Id", "Id");
            ViewData["PaisId"] = new SelectList(_context.SatPais, "Id", "Id");
            ViewData["RegimenFiscalId"] = new SelectList(_context.SatRegimenFiscals, "Id", "Id");
            ViewData["TipoConstitucionId"] = new SelectList(_context.TipoConstitucions, "Id", "Id");
            ViewData["TipoEmpresaId"] = new SelectList(_context.TipoEmpresas, "Id", "Id");
            ViewData["TipoHoraId"] = new SelectList(_context.SatTipoHoras, "Id", "Id");
            return View();
        }

        // POST: Empresas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaAlta,Rfc,Nombre,Calle,NumeroExt,NumeroInt,Colonia,Cp,Curp,MunicipioId,EstadoId,PaisId,Email,TipoComprobante,PathLogo,PathCertificadoSat,PathLlaveSat,ContraseñaSat,ProveedorSat,PathTimbrado,MonedaId,RegimenFiscalId,CumpleReqCuotas,ClaveImss,ClaveInfonavit,ClaveFonacot,LugarExpedicion,TipoEmpresaId,TipoHoraId,PorcentajePresFed,TelefonoWhatsApp,TelefonoFijo,TipoConstitucionId,Estatus")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoId"] = new SelectList(_context.SatEstados, "Id", "Id", empresa.EstadoId);
            ViewData["MonedaId"] = new SelectList(_context.SatMoneda, "Id", "Id", empresa.MonedaId);
            ViewData["MunicipioId"] = new SelectList(_context.SatMunicipios, "Id", "Id", empresa.MunicipioId);
            ViewData["PaisId"] = new SelectList(_context.SatPais, "Id", "Id", empresa.PaisId);
            ViewData["RegimenFiscalId"] = new SelectList(_context.SatRegimenFiscals, "Id", "Id", empresa.RegimenFiscalId);
            ViewData["TipoConstitucionId"] = new SelectList(_context.TipoConstitucions, "Id", "Id", empresa.TipoConstitucionId);
            ViewData["TipoEmpresaId"] = new SelectList(_context.TipoEmpresas, "Id", "Id", empresa.TipoEmpresaId);
            ViewData["TipoHoraId"] = new SelectList(_context.SatTipoHoras, "Id", "Id", empresa.TipoHoraId);
            return View(empresa);
        }

        // GET: Empresas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }
            ViewData["EstadoId"] = new SelectList(_context.SatEstados, "Id", "Id", empresa.EstadoId);
            ViewData["MonedaId"] = new SelectList(_context.SatMoneda, "Id", "Id", empresa.MonedaId);
            ViewData["MunicipioId"] = new SelectList(_context.SatMunicipios, "Id", "Id", empresa.MunicipioId);
            ViewData["PaisId"] = new SelectList(_context.SatPais, "Id", "Id", empresa.PaisId);
            ViewData["RegimenFiscalId"] = new SelectList(_context.SatRegimenFiscals, "Id", "Id", empresa.RegimenFiscalId);
            ViewData["TipoConstitucionId"] = new SelectList(_context.TipoConstitucions, "Id", "Id", empresa.TipoConstitucionId);
            ViewData["TipoEmpresaId"] = new SelectList(_context.TipoEmpresas, "Id", "Id", empresa.TipoEmpresaId);
            ViewData["TipoHoraId"] = new SelectList(_context.SatTipoHoras, "Id", "Id", empresa.TipoHoraId);
            return View(empresa);
        }

        // POST: Empresas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaAlta,Rfc,Nombre,Calle,NumeroExt,NumeroInt,Colonia,Cp,Curp,MunicipioId,EstadoId,PaisId,Email,TipoComprobante,PathLogo,PathCertificadoSat,PathLlaveSat,ContraseñaSat,ProveedorSat,PathTimbrado,MonedaId,RegimenFiscalId,CumpleReqCuotas,ClaveImss,ClaveInfonavit,ClaveFonacot,LugarExpedicion,TipoEmpresaId,TipoHoraId,PorcentajePresFed,TelefonoWhatsApp,TelefonoFijo,TipoConstitucionId,Estatus")] Empresa empresa)
        {
            if (id != empresa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaExists(empresa.Id))
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
            ViewData["EstadoId"] = new SelectList(_context.SatEstados, "Id", "Id", empresa.EstadoId);
            ViewData["MonedaId"] = new SelectList(_context.SatMoneda, "Id", "Id", empresa.MonedaId);
            ViewData["MunicipioId"] = new SelectList(_context.SatMunicipios, "Id", "Id", empresa.MunicipioId);
            ViewData["PaisId"] = new SelectList(_context.SatPais, "Id", "Id", empresa.PaisId);
            ViewData["RegimenFiscalId"] = new SelectList(_context.SatRegimenFiscals, "Id", "Id", empresa.RegimenFiscalId);
            ViewData["TipoConstitucionId"] = new SelectList(_context.TipoConstitucions, "Id", "Id", empresa.TipoConstitucionId);
            ViewData["TipoEmpresaId"] = new SelectList(_context.TipoEmpresas, "Id", "Id", empresa.TipoEmpresaId);
            ViewData["TipoHoraId"] = new SelectList(_context.SatTipoHoras, "Id", "Id", empresa.TipoHoraId);
            return View(empresa);
        }

        // GET: Empresas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas
                .Include(e => e.Estado)
                .Include(e => e.Moneda)
                .Include(e => e.Municipio)
                .Include(e => e.Pais)
                .Include(e => e.RegimenFiscal)
                .Include(e => e.TipoConstitucion)
                .Include(e => e.TipoEmpresa)
                .Include(e => e.TipoHora)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa != null)
            {
                _context.Empresas.Remove(empresa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpresaExists(int id)
        {
            return _context.Empresas.Any(e => e.Id == id);
        }
    }
}
