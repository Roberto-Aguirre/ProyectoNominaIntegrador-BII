using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoNominaINTBII.Data;
using ProyectoNominaINTBII.Models;

namespace ProyectoNominaINTBII.Controllers
{
    public class NominaDetalleController : Controller
    {
        private readonly ProyDb2bContext _context;

        public NominaDetalleController(ProyDb2bContext context)
        {
            _context = context;
        }

        // GET: NominaDetalle
        public async Task<IActionResult> Index()
        {
            var proyDb2bContext = _context.NominaDetalles
                .Include(n => n.Empresa)
                .Include(n => n.Incidencia)
                .Include(n => n.Periodo)
                .Include(n => n.Trabajador);
            return View(await proyDb2bContext.ToListAsync());
        }

        // GET: NominaDetalle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nominaDetalle = await _context.NominaDetalles
                .Include(n => n.Empresa)
                .Include(n => n.Incidencia)
                .Include(n => n.Periodo)
                .Include(n => n.Trabajador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nominaDetalle == null)
            {
                return NotFound();
            }

            return View(nominaDetalle);
        }

        // GET: NominaDetalle/Create
        public IActionResult Create()
        {
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Nombre");
            ViewData["IncidenciaId"] = new SelectList(_context.Incidencias, "Id", "Descripcion");
            ViewData["PeriodoId"] = new SelectList(_context.Incidencias, "Id", "Descripcion");
            ViewData["TrabajadorId"] = new SelectList(_context.Trabajadors, "Id", "NumEmpleado");
            return View();
        }

        // POST: NominaDetalle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmpresaId,PeriodoId,TrabajadorId,IncidenciaId,TipoIncapacidadId,DiasPagados,HorasExtra,Importe,Gravado,Exento,IsraPagar,BaseImpuesto,TipoCaptura,Comentarios,Estatus")] NominaDetalle nominaDetalle)
        {

            Trabajador trabajador = await _context.Trabajadors.FindAsync(nominaDetalle.TrabajadorId);
            nominaDetalle.Importe = trabajador.SalarioDiario * nominaDetalle.DiasPagados;
                _context.Add(nominaDetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            ViewData["EmpresaId"] = new SelectList(_context.Empresas.ToList(), "Id", "Descripcion", nominaDetalle.EmpresaId);
            ViewData["IncidenciaId"] = new SelectList(_context.Incidencias, "Id", "Descripcion", nominaDetalle.IncidenciaId);
            ViewData["PeriodoId"] = new SelectList(_context.Periodos, "Id", "Descripcion", nominaDetalle.PeriodoId);
            ViewData["TrabajadorId"] = new SelectList(_context.Trabajadors, "Id", "NumEmpleado", nominaDetalle.TrabajadorId);
            return View(nominaDetalle);
        }

        // GET: NominaDetalle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nominaDetalle = await _context.NominaDetalles.FindAsync(id);
            if (nominaDetalle == null)
            {
                return NotFound();
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Nombre", nominaDetalle.EmpresaId);
            ViewData["IncidenciaId"] = new SelectList(_context.Incidencias, "Id", "Descripcion", nominaDetalle.IncidenciaId);
            ViewData["PeriodoId"] = new SelectList(_context.Periodos, "Id", "Id", nominaDetalle.PeriodoId);
            ViewData["TrabajadorId"] = new SelectList(_context.Trabajadors, "Id", "NumEmpleado", nominaDetalle.TrabajadorId);
            return View(nominaDetalle);
        }

        // POST: NominaDetalle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmpresaId,PeriodoId,TrabajadorId,IncidenciaId,TipoIncapacidadId,DiasPagados,HorasExtra,Importe,Gravado,Exento,IsraPagar,BaseImpuesto,TipoCaptura,Comentarios,Estatus")] NominaDetalle nominaDetalle)
        {
            if (id != nominaDetalle.Id)
            {
                return NotFound();
            }

         
                try
                {
                    _context.Update(nominaDetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NominaDetalleExists(nominaDetalle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Nombre", nominaDetalle.EmpresaId);
            ViewData["IncidenciaId"] = new SelectList(_context.Incidencias, "Id", "Descripcion", nominaDetalle.IncidenciaId);
            ViewData["PeriodoId"] = new SelectList(_context.Periodos, "Id", "Id", nominaDetalle.PeriodoId);
            ViewData["TrabajadorId"] = new SelectList(_context.Trabajadors, "Id", "NumEmpleado", nominaDetalle.TrabajadorId);
            return View(nominaDetalle);
        }

        // GET: NominaDetalle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nominaDetalle = await _context.NominaDetalles
                .Include(n => n.Empresa)
                .Include(n => n.Incidencia)
                .Include(n => n.Periodo)
                .Include(n => n.Trabajador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nominaDetalle == null)
            {
                return NotFound();
            }

            return View(nominaDetalle);
        }

        // POST: NominaDetalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nominaDetalle = await _context.NominaDetalles.FindAsync(id);
            if (nominaDetalle != null)
            {
                _context.NominaDetalles.Remove(nominaDetalle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NominaDetalleExists(int id)
        {
            return _context.NominaDetalles.Any(e => e.Id == id);
        }
    }
}
