//using Microsoft.AspNetCore.Mvc;
//using ProyectoNominaINTBII.Models;

//namespace ProyectoNominaINTBII.Controllers
//{
//    public class CompanyController : Controller
//    {
//        // Simulación de una base de datos temporal (lista estática)
//        private static CompanyInfoModel companyInfo = new CompanyInfoModel
//        {
//            Id = 1,
//            Nombre = "Empresa Ejemplo",
//            Direccion = "Calle Falsa 123",
//            Telefono = "555-1234",
//            Email = "contacto@empresa.com",
//            RFC = "RFC123456789"
//        };

//        // Acción para mostrar la información de la empresa
//        [HttpGet]
//        public IActionResult CompanyInfo()
//        {
//            return View(companyInfo);
//        }

//        // Acción para actualizar la información de la empresa
//        [HttpPost]
//        public IActionResult UpdateCompanyInfo([FromBody] CompanyInfoModel infoActualizada)
//        {
//            if (ModelState.IsValid)
//            {
//                companyInfo.Nombre = infoActualizada.Nombre;
//                companyInfo.Direccion = infoActualizada.Direccion;
//                companyInfo.Telefono = infoActualizada.Telefono;
//                companyInfo.Email = infoActualizada.Email;
//                companyInfo.RFC = infoActualizada.RFC;

//                return Json(new { success = true, message = "Información actualizada correctamente." });
//            }

//            return Json(new { success = false, message = "Hubo un error al actualizar la información." });
//        }
//    }
//}
