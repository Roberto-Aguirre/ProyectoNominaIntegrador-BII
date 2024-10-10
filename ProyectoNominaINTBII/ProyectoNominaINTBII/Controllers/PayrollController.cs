using Microsoft.AspNetCore.Mvc;
using SistemaNomina.Models;
using SistemaNomina.Services;  // Importa el servicio
using System;
using System.Collections.Generic;
using System.Linq;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.IO;  // Necesario para MemoryStream

namespace SistemaNomina.Controllers
{
    public class PayrollController : Controller
    {
        private EmployeeService employeeService = new EmployeeService();  // Instancia del servicio
        private static List<PayrollModel> payrolls = new List<PayrollModel>();

        // Acción para mostrar la lista de nóminas (GET)
        public IActionResult Index()
        {
            return View(payrolls);  // Pasar la lista de nóminas a la vista
        }

        // Acción para mostrar la vista de selección de empleado para generar nómina (GET)
        [HttpGet]
        public IActionResult Generate()
        {
            var employees = employeeService.GetEmployees();  // Obtener la lista de empleados
            return View(employees);  // Pasar la lista de empleados a la vista
        }

        // Acción para calcular y generar una nueva nómina (POST)
        [HttpPost]
        public IActionResult Generate(int employeeId)
        {
            // Buscar al empleado correspondiente usando el servicio
            var employee = employeeService.GetEmployeeById(employeeId);
            if (employee == null)
            {
                return NotFound();  // Devuelve si no encuentra al empleado
            }

            // Calcular percepciones
            decimal aguinaldo = employee.Aguinaldo / 12;  // Aguinaldo mensual (si es proporcional)
            decimal primaVacacional = employee.PrimaVacacional;
            decimal otrasPercepciones = 0;  // Aquí puedes agregar bonos o prestaciones adicionales
            decimal totalPercepciones = employee.SalarioDiario + aguinaldo + primaVacacional + otrasPercepciones;

            // Calcular deducciones
            decimal isr = CalcularISR(totalPercepciones);
            decimal imss = CalcularIMSS(employee.SalarioDiarioIntegrado);
            decimal infonavit = employee.TieneInfonavit ? employee.DescuentoInfonavit : 0;
            decimal fonacot = employee.TieneFonacot ? employee.DescuentoFonacot : 0;
            decimal otrasDeducciones = employee.OtrasDeducciones;
            decimal totalDeducciones = isr + imss + infonavit + fonacot + otrasDeducciones;

            // Calcular salario neto
            decimal salarioNeto = totalPercepciones - totalDeducciones;

            // Crear una nueva nómina
            var payroll = new PayrollModel
            {
                Id = payrolls.Count + 1,
                EmployeeId = employee.Id,
                Employee = employee,
                SueldoBase = employee.SalarioDiario,
                Aguinaldo = aguinaldo,
                PrimaVacacional = primaVacacional,
                OtrasPercepciones = otrasPercepciones,
                TotalPercepciones = totalPercepciones,
                ISR = isr,
                IMSS = imss,
                Infonavit = infonavit,
                Fonacot = fonacot,
                OtrasDeducciones = otrasDeducciones,
                TotalDeducciones = totalDeducciones,
                SalarioNeto = salarioNeto,
                FechaPago = DateTime.Now
            };

            payrolls.Add(payroll);  // Agregar la nómina generada a la lista de nóminas

            // Redirigir a la lista de nóminas generadas
            return RedirectToAction("Index");  // Asegúrate de devolver algo siempre al final
        }

        // Exportar la lista de nóminas a PDF usando PdfSharp sin XFontStyle
        public IActionResult ExportToPDF()
        {
            // Crear un nuevo archivo PDF
            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = "Lista de Nóminas Generadas";

            // Crear una nueva página
            PdfPage pdfPage = pdf.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(pdfPage);
            XFont font = new XFont("Verdana", 12);  // Fuente sin estilos de XFontStyle
            XFont boldFont = new XFont("Verdana", 18);  // Fuente en negrita sin necesidad de XFontStyle.Bold

            // Escribir el título en el PDF
            gfx.DrawString("Lista de Nóminas Generadas", boldFont, XBrushes.Black, new XRect(0, 0, pdfPage.Width, pdfPage.Height), XStringFormats.TopCenter);

            // Configurar las posiciones iniciales para el contenido
            int yPoint = 40;

            // Escribir las columnas de encabezado
            gfx.DrawString("Empleado", font, XBrushes.Black, new XRect(40, yPoint, pdfPage.Width, pdfPage.Height), XStringFormats.TopLeft);
            gfx.DrawString("Sueldo Base", font, XBrushes.Black, new XRect(140, yPoint, pdfPage.Width, pdfPage.Height), XStringFormats.TopLeft);
            gfx.DrawString("Aguinaldo", font, XBrushes.Black, new XRect(240, yPoint, pdfPage.Width, pdfPage.Height), XStringFormats.TopLeft);
            gfx.DrawString("Prima Vacacional", font, XBrushes.Black, new XRect(340, yPoint, pdfPage.Width, pdfPage.Height), XStringFormats.TopLeft);
            gfx.DrawString("ISR", font, XBrushes.Black, new XRect(440, yPoint, pdfPage.Width, pdfPage.Height), XStringFormats.TopLeft);
            yPoint += 30;

            // Escribir los datos de cada nómina
            foreach (var payroll in payrolls)
            {
                gfx.DrawString(payroll.Employee.Nombre, font, XBrushes.Black, new XRect(40, yPoint, pdfPage.Width, pdfPage.Height), XStringFormats.TopLeft);
                gfx.DrawString(payroll.SueldoBase.ToString("C"), font, XBrushes.Black, new XRect(140, yPoint, pdfPage.Width, pdfPage.Height), XStringFormats.TopLeft);
                gfx.DrawString(payroll.Aguinaldo.ToString("C"), font, XBrushes.Black, new XRect(240, yPoint, pdfPage.Width, pdfPage.Height), XStringFormats.TopLeft);
                gfx.DrawString(payroll.PrimaVacacional.ToString("C"), font, XBrushes.Black, new XRect(340, yPoint, pdfPage.Width, pdfPage.Height), XStringFormats.TopLeft);
                gfx.DrawString(payroll.ISR.ToString("C"), font, XBrushes.Black, new XRect(440, yPoint, pdfPage.Width, pdfPage.Height), XStringFormats.TopLeft);
                yPoint += 30;
            }

            // Guardar el PDF en memoria y devolverlo
            MemoryStream stream = new MemoryStream();
            pdf.Save(stream, false);
            byte[] pdfBytes = stream.ToArray();

            // Retornar el archivo PDF
            return File(pdfBytes, "application/pdf", "NominasGeneradas.pdf");
        }

        // Métodos para calcular ISR e IMSS (simplificados para fines de ejemplo)
        private decimal CalcularISR(decimal totalPercepciones)
        {
            // Cálculo simplificado del ISR usando las tablas del SAT (usar fórmulas reales)
            return totalPercepciones * 0.10m;  // 10% como ejemplo
        }

        private decimal CalcularIMSS(decimal salarioDiarioIntegrado)
        {
            // Cálculo simplificado del IMSS (usar tablas oficiales)
            return salarioDiarioIntegrado * 0.065m;  // 6.5% como ejemplo
        }
    }
}
