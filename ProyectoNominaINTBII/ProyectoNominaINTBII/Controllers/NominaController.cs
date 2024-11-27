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
        public async Task<IActionResult> Create([Bind("Id,EmpresaId,Ejercicio,FechaPago,PeriodoId,ConceptoNomina,ConceptoTimbrado,Extraordinaria,Autorizada,Timbrada,Cerrada")] Nomina nomina)
        {
            
            Periodo periodo = await _context.Periodos.FindAsync(nomina.PeriodoId);
            nomina.FechaInicial = periodo.FechaInicial;
            nomina.FechaFinal = periodo.FechaFinal;
            nomina.Ejercicio = DateTime.UtcNow.Year;
            Trabajador trabajadordummy = await _context.Trabajadors.FirstOrDefaultAsync(e => e.EmpresaId == nomina.EmpresaId);
            nomina.SatPeriocidadPagoId = trabajadordummy.PeriocidadPagoId;
            nomina.SatTipoContratoId = trabajadordummy.TipoContratoId;

            if (nomina.Extraordinaria)
                nomina.NominaExtraordinariaId = 1;
            else
                nomina.NominaExtraordinariaId = 0;


       NominaDetalle baseNomina = new NominaDetalle();
            baseNomina.EmpresaId = nomina.EmpresaId;
            baseNomina.PeriodoId = nomina.PeriodoId;
            baseNomina.TipoIncapacidadId = 0;
            baseNomina.DiasPagados = 10;
            baseNomina.Comentarios = "";
            baseNomina.Estatus = "I";
            baseNomina.HorasExtra = 0;
            baseNomina.TipoCaptura = 0;
            //baseNomina.BaseImpuesto =
            //baseNomina.

            //baseNomina.BaseImpuesto 

            List<Trabajador> trabajadoresNomina = await _context.Trabajadors.ToListAsync();

            foreach (var item in trabajadoresNomina)
            {

                NominaDetalle nominaEstandar = baseNomina;
                nominaEstandar.TrabajadorId = item.Id;
                nominaEstandar.IncidenciaId = 1;
                nominaEstandar.Gravado = item.SalarioDiario * nominaEstandar.DiasPagados;
                nominaEstandar.Exento = 0;
                double salario = Double.Parse(nominaEstandar.Gravado.ToString());
                if (salario >= 0.01  && salario <= 368.1)
                {
                    nominaEstandar.BaseImpuesto =(decimal)1.92;
                    nominaEstandar.IsraPagar = (decimal)(((salario-0.01)*0.0192)+0);
                    nominaEstandar.Importe = nominaEstandar.Gravado - nominaEstandar.IsraPagar;

                }
                else if (salario >=368.11 && salario<=3124.35)
                {
                    nominaEstandar.BaseImpuesto = (decimal)6.4;
                    nominaEstandar.IsraPagar = (decimal)(((salario- 368.11) * 0.064)+ 7.05);
                    nominaEstandar.Importe = nominaEstandar.Gravado - nominaEstandar.IsraPagar;


                }
                else if (salario>=3124.36 && salario<=5490.75)
                {
                    nominaEstandar.BaseImpuesto = (decimal)10.88;
                    nominaEstandar.IsraPagar = (decimal)(((salario- 3124.36) * 0.1088)+ 183.45);
                    nominaEstandar.Importe = nominaEstandar.Gravado - nominaEstandar.IsraPagar;

                }
                else if (salario >= 5490.76 && salario <= 6382.8)
                {
                    nominaEstandar.BaseImpuesto = (decimal)16;
                    nominaEstandar.IsraPagar = (decimal)(((salario- 5490.76) * 0.16)+ 441);
                    nominaEstandar.Importe = nominaEstandar.Gravado - nominaEstandar.IsraPagar;

                }
                else if (salario >= 6382.81 && salario <= 7641.9)
                {
                    nominaEstandar.BaseImpuesto = (decimal)17.92;
                    nominaEstandar.IsraPagar = (decimal)(((salario- 6382.81) * 0.1792)+ 583.65);
                    nominaEstandar.Importe = nominaEstandar.Gravado - nominaEstandar.IsraPagar;

                }
                else if (salario >= 7641.91 && salario <= 15412.8)
                {
                    nominaEstandar.BaseImpuesto = (decimal)21.36;
                    nominaEstandar.IsraPagar = (decimal)(((salario- 7641.91) * 0.2136)+ 809.25);
                    nominaEstandar.Importe = nominaEstandar.Gravado - nominaEstandar.IsraPagar;

                }
                else if (salario >= 15412.81 && salario <= 24292.65)
                {
                    nominaEstandar.BaseImpuesto = (decimal)23.52;
                    nominaEstandar.IsraPagar = (decimal)(((salario- 15412.81) * 0.2352)+ 2469.15);
                    nominaEstandar.Importe = nominaEstandar.Gravado - nominaEstandar.IsraPagar;

                }
                else if (salario >= 24292.66 && salario <= 46378.5)
                {
                    nominaEstandar.BaseImpuesto = (decimal)30;
                    nominaEstandar.IsraPagar = (decimal)(((salario- 24292.66) * 0.30)+ 4557.75);
                    nominaEstandar.Importe = nominaEstandar.Gravado - nominaEstandar.IsraPagar;


                }
                else if (salario >= 46378.51 && salario <= 61838.1)
                {
                    nominaEstandar.BaseImpuesto = (decimal)32 ;
                    nominaEstandar.IsraPagar = (decimal)(((salario- 46378.51) * 0.32)+ 11183.4);
                    nominaEstandar.Importe = nominaEstandar.Gravado - nominaEstandar.IsraPagar;

                }
                else if (salario >= 61838.11 && salario <= 185514.3)
                {
                    nominaEstandar.BaseImpuesto = (decimal) 34;
                    nominaEstandar.IsraPagar = (decimal)(((salario- 61838.11) * 0.34)+ 16130.55);
                    nominaEstandar.Importe = nominaEstandar.Gravado - nominaEstandar.IsraPagar;

                }
                else if (salario >= 185514.31)
                {
                    nominaEstandar.IsraPagar = (decimal)(((salario- 61838.11) * 0.35)+ 58180.35);
                    nominaEstandar.BaseImpuesto = (decimal) 35;
                    nominaEstandar.Importe = nominaEstandar.Gravado - nominaEstandar.IsraPagar;

                }
                _context.Add(nominaEstandar);
                _context.SaveChanges();
            }

            nomina.TotalTrabajadores = trabajadoresNomina.Count;
            List<NominaDetalle> trabajadoresAlta = await _context.NominaDetalles.ToListAsync();
            trabajadoresAlta = trabajadoresAlta.FindAll(tra => tra.PeriodoId == nomina.PeriodoId);
            decimal deducion = 0;
            decimal totalPersepciones = 0;
            foreach (var item in trabajadoresAlta)
            {
                deducion += item.IsraPagar;
                totalPersepciones = item.Importe;
                
            }



            nomina.TotalDeducciones = deducion;
            nomina.TotalPercepciones = totalPersepciones;
            nomina.Generada = true;
            nomina.Estatus = "I";

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
