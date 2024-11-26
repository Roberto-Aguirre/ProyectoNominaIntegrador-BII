using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProyectoNominaINTBII.Data;
using ProyectoNominaINTBII.Models;
using ProyectoNominaINTBII.ViewModels;



namespace ProyectoNominaINTBII.Controllers
{
    public class AdminController : Controller
    {

        private readonly ProyDb2bContext _context;

        public AdminController(ProyDb2bContext context)
        {
            _context = context;
        }


        private static List<UserModel> users = new List<UserModel>();

        [HttpGet]
        public IActionResult AdminDashboard()
        {
            if (HttpContext.Session.GetString("UserSession") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }


        [HttpGet]
        public IActionResult ViewUserInfo(int id)
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
            {
                return Unauthorized();
            }

            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            var userModel = new UserModel
            {
                Sexos = _context.Sexos.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Descipcion }).ToList(),
                EstadosCiviles = _context.EstadoCivils.Select(ec => new SelectListItem { Value = ec.Id.ToString(), Text = ec.Descripcion }).ToList(),
                Paises = _context.SatPais.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.DescripcionSat }).ToList(),
                Municipios = _context.SatMunicipios.Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.DescripcionSat }).ToList(),
                Estados = _context.SatEstados.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.DescripcionSat }).ToList(),
                Bancos = _context.SatBancos.Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.DescripcionSat }).ToList(),
                TiposRegimen = _context.SatTipoRegimen.Select(tr => new SelectListItem { Value = tr.Id.ToString(), Text = tr.DescripcionSat }).ToList(),
                Puestos = _context.Puestos.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Descripcion }).ToList(),
                Departamentos = _context.Departamentos.Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Descripcion }).ToList(),
                TiposJornada = _context.SatTipoJornada.Select(tj => new SelectListItem { Value = tj.Id.ToString(), Text = tj.DescripcionSat }).ToList(),
                FormasPago = _context.SatFormaPagos.Select(fp => new SelectListItem { Value = fp.Id.ToString(), Text = fp.DescripcionSat }).ToList(),
                PeriodicidadesPago = _context.SatPeriocidadPagos.Select(pp => new SelectListItem { Value = pp.Id.ToString(), Text = pp.DescripcionSat }).ToList(),
                TiposContrato = _context.SatTipoContratos.Select(tc => new SelectListItem { Value = tc.Id.ToString(), Text = tc.Descripcion }).ToList(),
                TiposEmpleado = _context.TipoEmpleados.Select(te => new SelectListItem { Value = te.Id.ToString(), Text = te.Descipcion }).ToList(),
            };

            return View(userModel);
        }

        [HttpPost]
        public IActionResult CreateUser(UserModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.FechaIngreso = model.FechaIngreso == default(DateTime) ? DateTime.Now : model.FechaIngreso;
                    model.FechaNac = model.FechaNac == default(DateTime) ? new DateTime(2000, 1, 1) : model.FechaNac;
                    model.MotivoNoTimbrarId = model.MotivoNoTimbrarId == 0
                                ? _context.MotivoNoTimbrars.FirstOrDefault()?.Id ?? 0 // Asigna el primer ID válido de la tabla MotivoNoTimbrar, o 0 si no hay valor
                                : model.MotivoNoTimbrarId;

                    model.Estatus = string.IsNullOrEmpty(model.Estatus) ? "A" : model.Estatus;  // Asignamos 'A' por defecto si está vacío

                    model.PeriodicidadPagoId = model.PeriodicidadPagoId == 0
                ? _context.SatPeriocidadPagos.FirstOrDefault()?.Id ?? 1 // Asigna el primer ID válido de la tabla SatPeriocidadPago, o 1 si no hay valor
                : model.PeriodicidadPagoId;

                    var trabajador = new Trabajador
                    {
                        EmpresaId = 1,  // Asignar un valor fijo o dinámico según corresponda
                        TipoEmpleadoId = model.TipoEmpleadoId,
                        TipoContratoId = model.TipoContratoId,
                        NumEmpleado = model.NumEmpleado,
                        Nombre = model.Nombre,
                        ApellidoPaterno = model.ApellidoPaterno,
                        ApellidoMaterno = model.ApellidoMaterno,
                        SexoId = model.SexoId,
                        EstadoCivilId = model.EstadoCivilId,
                        FechaNac = model.FechaNac,  // Asignar la fecha de nacimiento
                        Calle = model.Calle,
                        NumeroExt = model.NumeroExt,
                        NumeroInt = model.NumeroInt ?? "S/N",  // Valor por defecto
                        Colonia = model.Colonia,
                        Cp = model.CP,
                        PaisId = model.PaisId,
                        MunicipioId = model.MunicipioId,
                        EstadoId = model.EstadoId,
                        TelefonoMovil = model.TelefonoMovil ?? "0000000000",  // Valor predeterminado
                        TelefonoFijo = model.TelefonoFijo ?? "0000000000",  // Valor predeterminado
                        Rfc = model.RFC,
                        Curp = model.CURP,
                        Nss = model.NSS,
                        FechaIngreso = model.FechaIngreso,
                        FechaBaja = null,  // No se asigna al crear el usuario
                        PeriocidadPagoId = model.PeriodicidadPagoId,
                        FormaPagoId = model.FormaPagoId,
                        CuentaBanco = model.CuentaBanco != 0 ? model.CuentaBanco : 12345678,  // Valor predeterminado
                        Clabe = model.CLABE ?? "12345678901234567A",  // Valor predeterminado
                        BancoId = model.BancoId,
                        Email = model.Email ?? "correo@example.com",  // Valor predeterminado
                        Salario = model.Salario,
                        SalarioDiario = model.Salario / 30,  // Ejemplo de cálculo
                        SalarioDiarioInte = model.SalarioDiarioInte,
                        CumpleReqDisminucion = false,  // Valor predeterminado
                        TipoRegimenId = model.TipoRegimenId,
                        PuestoId = model.PuestoId,
                        DepartamentoId = model.DepartamentoId,
                        BaseCotizacionId = 1,  // Valor predeterminado
                        TipoJornadaId = model.TipoJornadaId,
                        OrigenRecursoId = 1,  // Valor predeterminado
                        PorcentajePresFed = 0.0M,  // Valor predeterminado
                        MontoPropio = 0.0M,  // Valor predeterminado
                        NominaGen = false,  // Valor predeterminado
                        EmpresaRegimenPatId = 1,  // Valor predeterminado
                        EstatusTimbrado = 0,  // Valor predeterminado
                        MotivoNoTimbrarId = model.MotivoNoTimbrarId, // Asignar el valor de MotivoNoTimbrarId (ya validado)
                        Estatus = model.Estatus, // Asignamos el valor de Estatus (que ahora no es NULL)


                    };

                    // Guardar el trabajador en la base de datos
                    _context.Trabajadors.Add(trabajador);
                    _context.SaveChanges();

                    // Mensaje de éxito
                    TempData["SuccessMessage"] = "Usuario creado correctamente.";
                    return RedirectToAction("ListUsers");
                }
                else
                {
                    // Capturar errores del ModelState para depuración
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                    TempData["ErrorMessage"] = string.Join(", ", errors);
                }
            }
            catch (Exception ex)
            {
                // Si hay una excepción interna, capturar el mensaje completo
                string innerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : "No hay excepción interna.";
                TempData["ErrorMessage"] = $"Ocurrió un error al guardar: {ex.Message}. Excepción interna: {innerExceptionMessage}";
            }

            // Si hay un error, regresar al formulario con el modelo actual
            return View(model);
        }





        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = _context.Trabajadors.ToList();
            return View(users);
        }




        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                users.Remove(user);
                return Ok();
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult EditAllUsersInfo(int id)
        {
            var trabajador = _context.Trabajadors.FirstOrDefault(t => t.Id == id);

            if (trabajador == null)
            {
                return NotFound(); // Si no se encuentra el trabajador, retorna un error 404
            }

            var model = new UserModel
            {
                Id = trabajador.Id,
                Nombre = trabajador.Nombre,
                ApellidoPaterno = trabajador.ApellidoPaterno,
                ApellidoMaterno = trabajador.ApellidoMaterno,
                NumEmpleado = trabajador.NumEmpleado,
                RFC = trabajador.Rfc,
                CURP = trabajador.Curp,
                FechaIngreso = trabajador.FechaIngreso,
                TelefonoMovil = trabajador.TelefonoMovil,
                TelefonoFijo = trabajador.TelefonoFijo,
                Email = trabajador.Email,
                Salario = trabajador.Salario,
                SalarioDiario = trabajador.SalarioDiario,
                PuestoId = trabajador.PuestoId, // Asegúrate de que esta propiedad esté bien mapeada
                DepartamentoId = trabajador.DepartamentoId,
                Puestos = _context.Puestos.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Descripcion
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EditAllUsersInfo(UserModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var trabajador = _context.Trabajadors.FirstOrDefault(t => t.Id == model.Id);

                    if (trabajador == null)
                    {
                        return NotFound();
                    }

                    trabajador.Nombre = model.Nombre;
                    trabajador.ApellidoPaterno = model.ApellidoPaterno;
                    trabajador.ApellidoMaterno = model.ApellidoMaterno;
                    trabajador.NumEmpleado = model.NumEmpleado;
                    trabajador.Rfc = model.RFC;
                    trabajador.Curp = model.CURP;
                    trabajador.FechaIngreso = model.FechaIngreso;
                    trabajador.TelefonoMovil = model.TelefonoMovil;
                    trabajador.TelefonoFijo = model.TelefonoFijo;
                    trabajador.Email = model.Email;
                    trabajador.Salario = model.Salario;
                    trabajador.SalarioDiario = model.SalarioDiario;
                    trabajador.PuestoId = model.PuestoId;
                    trabajador.DepartamentoId = model.DepartamentoId;

                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Usuario actualizado correctamente.";
                    return RedirectToAction("ListUsers");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Ocurrió un error: {ex.Message}";
            }

            return View(model);
        }
    }
}


//        [HttpGet]
//        public async Task<IActionResult> CompanyInfo()
//        {
//            var empresa = await _context.Empresas.FirstOrDefaultAsync();
//            if (empresa == null)
//            {
//                return NotFound("Empresa no encontrada.");
//            }

//            var model = new CompanyInfoModel
//            {
//                Id = empresa.Id,
//                FechaAlta = empresa.FechaAlta,
//                RFC = empresa.RFC,
//                Nombre = empresa.Nombre,
//                Calle = empresa.Calle,
//                NumeroExt = empresa.NumeroExt,
//                NumeroInt = empresa.NumeroInt,
//                Colonia = empresa.Colonia,
//                CP = empresa.CP,
//                CURP = empresa.CURP,
//                MunicipioId = empresa.MunicipioId,
//                EstadoId = empresa.EstadoId,
//                PaisId = empresa.PaisId,
//                Email = empresa.Email,
//                TipoComprobante = empresa.TipoComprobante,
//                PathLogo = empresa.PathLogo,
//                PathCertificadoSAT = empresa.PathCertificadoSAT,
//                PathLlaveSAT = empresa.PathLlaveSAT,
//                ContraseñaSAT = empresa.ContraseñaSAT,
//                ProveedorSAT = empresa.ProveedorSAT,
//                PathTimbrado = empresa.PathTimbrado,
//                MonedaId = empresa.MonedaId,
//                RegimenFiscalId = empresa.RegimenFiscalId,
//                CumpleReqCuotas = empresa.CumpleReqCuotas,
//                ClaveIMSS = empresa.ClaveIMSS,
//                ClaveINFONAVIT = empresa.ClaveINFONAVIT,
//                ClaveFONACOT = empresa.ClaveFONACOT,
//                LugarExpedicion = empresa.LugarExpedicion,
//                TipoEmpresaId = empresa.TipoEmpresaId,
//                TipoHoraId = empresa.TipoHoraId,
//                PorcentajePresFed = empresa.PorcentajePresFed,
//                TelefonoWhatsApp = empresa.TelefonoWhatsApp,
//                TelefonoFijo = empresa.TelefonoFijo,
//                TipoConstitucionId = empresa.TipoConstitucionId,
//                Estatus = empresa.Estatus
//            };

//            return View(model);
//        }
//    }

//    [HttpPost]
//    public async Task<IActionResult> UpdateCompanyInfo([FromBody] CompanyInfoModel model)
//    {
//        var empresa = await _context.Empresas.FirstOrDefaultAsync(e => e.Id == model.Id);
//        if (empresa == null)
//        {
//            return NotFound("Empresa no encontrada.");
//        }

//        empresa.FechaAlta = model.FechaAlta;
//        empresa.RFC = model.RFC;
//        empresa.Nombre = model.Nombre;
//        empresa.Calle = model.Calle;
//        empresa.NumeroExt = model.NumeroExt;
//        empresa.NumeroInt = model.NumeroInt;
//        empresa.Colonia = model.Colonia;
//        empresa.CP = model.CP;
//        empresa.CURP = model.CURP;
//        empresa.MunicipioId = model.MunicipioId;
//        empresa.EstadoId = model.EstadoId;
//        empresa.PaisId = model.PaisId;
//        empresa.Email = model.Email;
//        empresa.TipoComprobante = model.TipoComprobante;
//        empresa.PathLogo = model.PathLogo;
//        empresa.PathCertificadoSAT = model.PathCertificadoSAT;
//        empresa.PathLlaveSAT = model.PathLlaveSAT;
//        empresa.ContraseñaSAT = model.ContraseñaSAT;
//        empresa.ProveedorSAT = model.ProveedorSAT;
//        empresa.PathTimbrado = model.PathTimbrado;
//        empresa.MonedaId = model.MonedaId;
//        empresa.RegimenFiscalId = model.RegimenFiscalId;
//        empresa.CumpleReqCuotas = model.CumpleReqCuotas;
//        empresa.ClaveIMSS = model.ClaveIMSS;
//        empresa.ClaveINFONAVIT = model.ClaveINFONAVIT;
//        empresa.ClaveFONACOT = model.ClaveFONACOT;
//        empresa.LugarExpedicion = model.LugarExpedicion;
//        empresa.TipoEmpresaId = model.TipoEmpresaId;
//        empresa.TipoHoraId = model.TipoHoraId;
//        empresa.PorcentajePresFed = model.PorcentajePresFed;
//        empresa.TelefonoWhatsApp = model.TelefonoWhatsApp;
//        empresa.TelefonoFijo = model.TelefonoFijo;
//        empresa.TipoConstitucionId = model.TipoConstitucionId;
//        empresa.Estatus = model.Estatus;

//        await _context.SaveChangesAsync();

//        return Json(new { success = true });
//    }
//}







