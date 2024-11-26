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
    public class TrabajadoresController : Controller
    {
        private readonly ProyDb2bContext _context;

        public TrabajadoresController(ProyDb2bContext context)
        {
            _context = context;
        }

        // GET: Trabajadores
        public async Task<IActionResult> Index()
        {
            var proyDb2bContext = _context.Trabajadors.Include(t => t.Banco).Include(t => t.BaseCotizacion).Include(t => t.Departamento).Include(t => t.Empresa).Include(t => t.EmpresaRegimenPat).Include(t => t.Estado).Include(t => t.EstadoCivil).Include(t => t.FormaPago).Include(t => t.MotivoNoTimbrar).Include(t => t.Municipio).Include(t => t.OrigenRecurso).Include(t => t.Pais).Include(t => t.PeriocidadPago).Include(t => t.Puesto).Include(t => t.Sexo).Include(t => t.TipoContrato).Include(t => t.TipoEmpleado).Include(t => t.TipoJornada).Include(t => t.TipoRegimen);
            return View(await proyDb2bContext.ToListAsync());
        }

        // GET: Trabajadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabajador = await _context.Trabajadors
                .Include(t => t.Banco)
                .Include(t => t.BaseCotizacion)
                .Include(t => t.Departamento)
                .Include(t => t.Empresa)
                .Include(t => t.EmpresaRegimenPat)
                .Include(t => t.Estado)
                .Include(t => t.EstadoCivil)
                .Include(t => t.FormaPago)
                .Include(t => t.MotivoNoTimbrar)
                .Include(t => t.Municipio)
                .Include(t => t.OrigenRecurso)
                .Include(t => t.Pais)
                .Include(t => t.PeriocidadPago)
                .Include(t => t.Puesto)
                .Include(t => t.Sexo)
                .Include(t => t.TipoContrato)
                .Include(t => t.TipoEmpleado)
                .Include(t => t.TipoJornada)
                .Include(t => t.TipoRegimen)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trabajador == null)
            {
                return NotFound();
            }

            return View(trabajador);
        }

        // GET: Trabajadores/Create
        public IActionResult Create()
        {
            ViewData["BancoId"] = new SelectList(_context.SatBancos, "Id", "DescripcionSat");
            ViewData["BaseCotizacionId"] = new SelectList(_context.BaseCotizacions, "Id", "Descripcion");
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "Id", "Descripcion");
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Nombre");
            ViewData["EmpresaRegimenPatId"] = new SelectList(_context.EmpresaRegPats, "Id", "Id");
            ViewData["EstadoId"] = new SelectList(_context.SatEstados, "Id", "DescripcionSat");
            ViewData["EstadoCivilId"] = new SelectList(_context.EstadoCivils, "Id", "Descripcion");
            ViewData["FormaPagoId"] = new SelectList(_context.SatFormaPagos, "Id", "DescripcionSat");
            ViewData["MotivoNoTimbrarId"] = new SelectList(_context.MotivoNoTimbrars, "Id", "Id");
            ViewData["MunicipioId"] = new SelectList(_context.SatMunicipios, "Id", "DescripcionSat");
            ViewData["OrigenRecursoId"] = new SelectList(_context.SatOrigenRecursos, "Id", "DscripcionSat");
            ViewData["PaisId"] = new SelectList(_context.SatPais, "Id", "DescripcionSat");
            ViewData["PeriocidadPagoId"] = new SelectList(_context.SatPeriocidadPagos, "Id", "DescripcionSat");
            ViewData["PuestoId"] = new SelectList(_context.Puestos, "Id", "Descripcion");
            ViewData["SexoId"] = new SelectList(_context.Sexos, "Id", "Descipcion");
            ViewData["TipoContratoId"] = new SelectList(_context.SatTipoContratos, "Id", "Descripcion");
            ViewData["TipoEmpleadoId"] = new SelectList(_context.TipoEmpleados, "Id", "Descipcion");
            ViewData["TipoJornadaId"] = new SelectList(_context.SatTipoJornada, "Id", "DescripcionSat");
            //ViewData["TipoRegimenId"] = new SelectList(_context.SatTipoRegimen, "Id", "DescripcionSat");
            return View();
        }

        // POST: Trabajadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmpresaId,TipoEmpleadoId,TipoContratoId,NumEmpleado,Nombre,ApellidoPaterno,ApellidoMaterno,SexoId,EstadoCivilId,FechaNac,Calle,NumeroExt,NumeroInt,Colonia,Cp,PaisId,MunicipioId,EstadoId,TelefonoMovil,TelefonoFijo,Rfc,Curp,Nss,FechaIngreso,FechaBaja,PeriocidadPagoId,FormaPagoId,CuentaBanco,Clabe,BancoId,Email,Salario,SalarioDiario,SalarioDiarioInte,CumpleReqDisminucion,TipoRegimenId,PuestoId,DepartamentoId,BaseCotizacionId,TipoJornadaId,OrigenRecursoId,PorcentajePresFed,MontoPropio,NominaGen,EmpresaRegimenPatId,EstatusTimbrado,MotivoNoTimbrarId,Estatus")] Trabajador trabajador)
        {

            _context.Add(trabajador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


            ViewData["BancoId"] = new SelectList(_context.SatBancos, "Id", "DescripcionSat", trabajador.BancoId);
            ViewData["BaseCotizacionId"] = new SelectList(_context.BaseCotizacions, "Id", "Descripcion", trabajador.BaseCotizacionId);
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "Id", "Descripcion", trabajador.DepartamentoId);
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Nombre", trabajador.EmpresaId);
            ViewData["EmpresaRegimenPatId"] = new SelectList(_context.EmpresaRegPats, "Id", "Id", trabajador.EmpresaRegimenPatId);
            ViewData["EstadoId"] = new SelectList(_context.SatEstados, "Id", "DescripcionSat", trabajador.EstadoId);
            ViewData["EstadoCivilId"] = new SelectList(_context.EstadoCivils, "Id", "Descripcion", trabajador.EstadoCivilId);
            ViewData["FormaPagoId"] = new SelectList(_context.SatFormaPagos, "Id", "DescripcionSat", trabajador.FormaPagoId);
            ViewData["MotivoNoTimbrarId"] = new SelectList(_context.MotivoNoTimbrars, "Id", "Id", trabajador.MotivoNoTimbrarId);
            ViewData["MunicipioId"] = new SelectList(_context.SatMunicipios, "Id", "DescripcionSat", trabajador.MunicipioId);
            ViewData["OrigenRecursoId"] = new SelectList(_context.SatOrigenRecursos, "Id", "DscripcionSat", trabajador.OrigenRecursoId);
            ViewData["PaisId"] = new SelectList(_context.SatPais, "Id", "DescripcionSat", trabajador.PaisId);
            ViewData["PeriocidadPagoId"] = new SelectList(_context.SatPeriocidadPagos, "Id", "DescripcionSat", trabajador.PeriocidadPagoId);
            ViewData["PuestoId"] = new SelectList(_context.Puestos, "Id", "Descripcion", trabajador.PuestoId);
            ViewData["SexoId"] = new SelectList(_context.Sexos, "Id", "Descipcion", trabajador.SexoId);
            ViewData["TipoContratoId"] = new SelectList(_context.SatTipoContratos, "Id", "Descripcion", trabajador.TipoContratoId);
            ViewData["TipoEmpleadoId"] = new SelectList(_context.TipoEmpleados, "Id", "Descipcion", trabajador.TipoEmpleadoId);
            ViewData["TipoJornadaId"] = new SelectList(_context.SatTipoJornada, "Id", "DescripcionSat", trabajador.TipoJornadaId);
            ViewData["TipoRegimenId"] = new SelectList(_context.SatTipoRegimen, "Id", "DescripcionSat", trabajador.TipoRegimenId);
            return View(trabajador);

        }

        // GET: Trabajadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabajador = await _context.Trabajadors.FindAsync(id);
            if (trabajador == null)
            {
                return NotFound();
            }
            ViewData["BancoId"] = new SelectList(_context.SatBancos, "Id", "DescripcionSat", trabajador.BancoId);
            ViewData["BaseCotizacionId"] = new SelectList(_context.BaseCotizacions, "Id", "Descripcion", trabajador.BaseCotizacionId);
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "Id", "Descripcion", trabajador.DepartamentoId);
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Nombre", trabajador.EmpresaId);
            ViewData["EmpresaRegimenPatId"] = new SelectList(_context.EmpresaRegPats, "Id", "Id", trabajador.EmpresaRegimenPatId);
            ViewData["EstadoId"] = new SelectList(_context.SatEstados, "Id", "DescripcionSat", trabajador.EstadoId);
            ViewData["EstadoCivilId"] = new SelectList(_context.EstadoCivils, "Id", "Descripcion", trabajador.EstadoCivilId);
            ViewData["FormaPagoId"] = new SelectList(_context.SatFormaPagos, "Id", "DescripcionSat", trabajador.FormaPagoId);
            ViewData["MotivoNoTimbrarId"] = new SelectList(_context.MotivoNoTimbrars, "Id", "Id", trabajador.MotivoNoTimbrarId);
            ViewData["MunicipioId"] = new SelectList(_context.SatMunicipios, "Id", "DescripcionSat", trabajador.MunicipioId);
            ViewData["OrigenRecursoId"] = new SelectList(_context.SatOrigenRecursos, "Id", "DscripcionSat", trabajador.OrigenRecursoId);
            ViewData["PaisId"] = new SelectList(_context.SatPais, "Id", "DescripcionSat", trabajador.PaisId);
            ViewData["PeriocidadPagoId"] = new SelectList(_context.SatPeriocidadPagos, "Id", "DescripcionSat", trabajador.PeriocidadPagoId);
            ViewData["PuestoId"] = new SelectList(_context.Puestos, "Id", "Descripcion", trabajador.PuestoId);
            ViewData["SexoId"] = new SelectList(_context.Sexos, "Id", "Descipcion", trabajador.SexoId);
            ViewData["TipoContratoId"] = new SelectList(_context.SatTipoContratos, "Id", "Descripcion", trabajador.TipoContratoId);
            ViewData["TipoEmpleadoId"] = new SelectList(_context.TipoEmpleados, "Id", "Descipcion", trabajador.TipoEmpleadoId);
            ViewData["TipoJornadaId"] = new SelectList(_context.SatTipoJornada, "Id", "DescripcionSat", trabajador.TipoJornadaId);
            ViewData["TipoRegimenId"] = new SelectList(_context.SatTipoRegimen, "Id", "DescripcionSat", trabajador.TipoRegimenId);
            return View(trabajador);
        }

        // POST: Trabajadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmpresaId,TipoEmpleadoId,TipoContratoId,NumEmpleado,Nombre,ApellidoPaterno,ApellidoMaterno,SexoId,EstadoCivilId,FechaNac,Calle,NumeroExt,NumeroInt,Colonia,Cp,PaisId,MunicipioId,EstadoId,TelefonoMovil,TelefonoFijo,Rfc,Curp,Nss,FechaIngreso,FechaBaja,PeriocidadPagoId,FormaPagoId,CuentaBanco,Clabe,BancoId,Email,Salario,SalarioDiario,SalarioDiarioInte,CumpleReqDisminucion,TipoRegimenId,PuestoId,DepartamentoId,BaseCotizacionId,TipoJornadaId,OrigenRecursoId,PorcentajePresFed,MontoPropio,NominaGen,EmpresaRegimenPatId,EstatusTimbrado,MotivoNoTimbrarId,Estatus")] Trabajador trabajador)
        {
            if (id != trabajador.Id)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(trabajador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrabajadorExists(trabajador.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            ViewData["BancoId"] = new SelectList(_context.SatBancos, "Id", "DescripcionSat", trabajador.BancoId);
            ViewData["BaseCotizacionId"] = new SelectList(_context.BaseCotizacions, "Id", "Descripcion", trabajador.BaseCotizacionId);
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "Id", "Descripcion", trabajador.DepartamentoId);
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Nombre", trabajador.EmpresaId);
            ViewData["EmpresaRegimenPatId"] = new SelectList(_context.EmpresaRegPats, "Id", "Id", trabajador.EmpresaRegimenPatId);
            ViewData["EstadoId"] = new SelectList(_context.SatEstados, "Id", "DescripcionSat", trabajador.EstadoId);
            ViewData["EstadoCivilId"] = new SelectList(_context.EstadoCivils, "Id", "Descripcion", trabajador.EstadoCivilId);
            ViewData["FormaPagoId"] = new SelectList(_context.SatFormaPagos, "Id", "DescripcionSat", trabajador.FormaPagoId);
            ViewData["MotivoNoTimbrarId"] = new SelectList(_context.MotivoNoTimbrars, "Id", "Id", trabajador.MotivoNoTimbrarId);
            ViewData["MunicipioId"] = new SelectList(_context.SatMunicipios, "Id", "DescripcionSat", trabajador.MunicipioId);
            ViewData["OrigenRecursoId"] = new SelectList(_context.SatOrigenRecursos, "Id", "DscripcionSat", trabajador.OrigenRecursoId);
            ViewData["PaisId"] = new SelectList(_context.SatPais, "Id", "DescripcionSat", trabajador.PaisId);
            ViewData["PeriocidadPagoId"] = new SelectList(_context.SatPeriocidadPagos, "Id", "DescripcionSat", trabajador.PeriocidadPagoId);
            ViewData["PuestoId"] = new SelectList(_context.Puestos, "Id", "Descripcion", trabajador.PuestoId);
            ViewData["SexoId"] = new SelectList(_context.Sexos, "Id", "Descipcion", trabajador.SexoId);
            ViewData["TipoContratoId"] = new SelectList(_context.SatTipoContratos, "Id", "Descripcion", trabajador.TipoContratoId);
            ViewData["TipoEmpleadoId"] = new SelectList(_context.TipoEmpleados, "Id", "Descipcion", trabajador.TipoEmpleadoId);
            ViewData["TipoJornadaId"] = new SelectList(_context.SatTipoJornada, "Id", "DescripcionSat", trabajador.TipoJornadaId);
            ViewData["TipoRegimenId"] = new SelectList(_context.SatTipoRegimen, "Id", "DescripcionSat", trabajador.TipoRegimenId);
            return View(trabajador);
        }


        // GET: Trabajadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabajador = await _context.Trabajadors
                .Include(t => t.Banco)
                .Include(t => t.BaseCotizacion)
                .Include(t => t.Departamento)
                .Include(t => t.Empresa)
                .Include(t => t.EmpresaRegimenPat)
                .Include(t => t.Estado)
                .Include(t => t.EstadoCivil)
                .Include(t => t.FormaPago)
                .Include(t => t.MotivoNoTimbrar)
                .Include(t => t.Municipio)
                .Include(t => t.OrigenRecurso)
                .Include(t => t.Pais)
                .Include(t => t.PeriocidadPago)
                .Include(t => t.Puesto)
                .Include(t => t.Sexo)
                .Include(t => t.TipoContrato)
                .Include(t => t.TipoEmpleado)
                .Include(t => t.TipoJornada)
                .Include(t => t.TipoRegimen)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trabajador == null)
            {
                return NotFound();
            }

            return View(trabajador);
        }

        // POST: Trabajadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trabajador = await _context.Trabajadors.FindAsync(id);
            if (trabajador != null)
            {
                _context.Trabajadors.Remove(trabajador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrabajadorExists(int id)
        {
            return _context.Trabajadors.Any(e => e.Id == id);
        }
    }
}
