using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using ProyectoNominaINTBII.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProyectoNominaINTBII.Controllers
{
    public class PayrollController : Controller
    {


        private static List<PayrollModel> payrolls = new List<PayrollModel>();

        [HttpGet]
        public IActionResult Index()
        {
            return View(payrolls);
        }

        [HttpPost]
        public IActionResult Generate(PayrollModel payroll)
        {
            if (payroll.Id > 0)
            {
                // Editar un registro existente
                var existingPayroll = payrolls.FirstOrDefault(p => p.Id == payroll.Id);
                if (existingPayroll != null)
                {
                    // Actualiza los datos del registro existente
                    existingPayroll.NombreEmpresa = payroll.NombreEmpresa;
                    existingPayroll.RFC_Empresa = payroll.RFC_Empresa;
                    existingPayroll.DireccionEmpresa = payroll.DireccionEmpresa;
                    existingPayroll.LugarExpedicion = payroll.LugarExpedicion;
                    existingPayroll.RegistroPatronal = payroll.RegistroPatronal;
                    existingPayroll.NumeroEmpleado = payroll.NumeroEmpleado;
                    existingPayroll.Empleado = payroll.Empleado;
                    existingPayroll.RFCEmpleado = payroll.RFCEmpleado;
                    existingPayroll.CURP = payroll.CURP;
                    existingPayroll.NumeroIMSS = payroll.NumeroIMSS;
                    existingPayroll.FechaInicioRelacion = payroll.FechaInicioRelacion;
                    existingPayroll.Puesto = payroll.Puesto;
                    existingPayroll.Departamento = payroll.Departamento;
                    existingPayroll.RegimenFiscal = payroll.RegimenFiscal;
                    existingPayroll.TipoDeJornada = payroll.TipoDeJornada;
                    existingPayroll.TipoDeContrato = payroll.TipoDeContrato;
                    existingPayroll.PeriodoPago = payroll.PeriodoPago;
                    existingPayroll.FechaPago = payroll.FechaPago;
                    existingPayroll.DiasLaborados = payroll.DiasLaborados;
                    existingPayroll.DiasPagados = payroll.DiasPagados;
                    existingPayroll.SalarioDiario = payroll.SalarioDiario;
                    existingPayroll.SBC = payroll.SBC;
                    existingPayroll.SDI = payroll.SDI;
                    existingPayroll.Percepciones = payroll.Percepciones;
                    existingPayroll.Deducciones = payroll.Deducciones;
                }
            }
            else
            {
                // Crear un nuevo registro
                payroll.Id = payrolls.Count > 0 ? payrolls.Max(p => p.Id) + 1 : 1;
                payrolls.Add(payroll);
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Detail(int id)
        {
            var nomina = payrolls.FirstOrDefault(p => p.Id == id);
            if (nomina == null)
            {
                return NotFound();
            }
            return View(nomina);
        }

        // Método de eliminación en PayrollController
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var payrollToDelete = payrolls.FirstOrDefault(p => p.Id == id);
            if (payrollToDelete != null)
            {
                payrolls.Remove(payrollToDelete);
            }
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Generate()
        {
            var payroll = new PayrollModel();
            return View(payroll);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Buscar el registro en la lista usando el ID
            var payroll = payrolls.FirstOrDefault(p => p.Id == id);
            if (payroll == null)
            {
                return NotFound(); // Si no se encuentra, retorna un error 404
            }

            return View(payroll); // Carga la vista Edit con el modelo Payroll
        }


        // Método POST para guardar los cambios en el registro
        [HttpPost]
        public IActionResult Edit(int id, PayrollModel updatedPayroll)
        {
            // Buscar el registro en la lista por ID
            var payroll = payrolls.FirstOrDefault(p => p.Id == id);

            if (payroll == null)
            {
                return NotFound(); // Si no se encuentra, retorna un error 404
            }

            // Actualizar los campos del registro con los valores del formulario
            payroll.NumeroEmpleado = updatedPayroll.NumeroEmpleado;
            payroll.Empleado = updatedPayroll.Empleado;
            payroll.RFCEmpleado = updatedPayroll.RFCEmpleado;
            payroll.CURP = updatedPayroll.CURP;
            payroll.NumeroIMSS = updatedPayroll.NumeroIMSS;
            payroll.FechaInicioRelacion = updatedPayroll.FechaInicioRelacion;
            payroll.Puesto = updatedPayroll.Puesto;
            payroll.Departamento = updatedPayroll.Departamento;
            payroll.PeriodoPago = updatedPayroll.PeriodoPago;
            payroll.FechaPago = updatedPayroll.FechaPago;
            payroll.DiasLaborados = updatedPayroll.DiasLaborados;
            payroll.DiasPagados = updatedPayroll.DiasPagados;
            payroll.SalarioDiario = updatedPayroll.SalarioDiario;
            payroll.SBC = updatedPayroll.SBC;
            payroll.SDI = updatedPayroll.SDI;

            // Redirigir al índice de Payrolls después de guardar
            return RedirectToAction("Index");
        }


    [HttpGet]
        public IActionResult DownloadPdf(int id)
        {
            // Cambiar la búsqueda a utilizar el Id en lugar del índice
            var payrollRecord = payrolls.FirstOrDefault(p => p.Id == id);
            if (payrollRecord == null)
            {
                return NotFound();
            }

            Document doc = new Document(PageSize.A4.Rotate(), 40, 40, 30, 30);
            MemoryStream stream = new MemoryStream();
            PdfWriter.GetInstance(doc, stream).CloseStream = false;
            doc.Open();

            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font textFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font smallTextFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL);

            // Tabla para mostrar datos de la empresa y fecha de pago en una misma fila
            PdfPTable empresaTable = new PdfPTable(2);
            empresaTable.WidthPercentage = 100;
            float[] empresaWidths = new float[] { 70f, 30f }; // Ajusta el ancho de las columnas según tus necesidades
            empresaTable.SetWidths(empresaWidths);

            // Celda para los datos de la empresa (Nombre, RFC, Dirección)
            PdfPCell empresaInfoCell = new PdfPCell();
            empresaInfoCell.Border = PdfPCell.NO_BORDER;
            empresaInfoCell.AddElement(new Paragraph(payrollRecord.NombreEmpresa, titleFont));
            empresaInfoCell.AddElement(new Paragraph($"RFC EMPRESA: {payrollRecord.RFC_Empresa}", textFont));
            empresaInfoCell.AddElement(new Paragraph($"Dirección: {payrollRecord.DireccionEmpresa}", textFont));
  
            // Celda para la fecha de pago, alineada a la derecha
            PdfPCell fechaPagoCell = new PdfPCell();
            fechaPagoCell.Border = PdfPCell.NO_BORDER;
            fechaPagoCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            fechaPagoCell.AddElement(new Paragraph("Fecha de Pago:", textFont));
            fechaPagoCell.AddElement(new Paragraph(payrollRecord.FechaPago?.ToString("dd-MM-yyyy") ?? DateTime.Now.ToString("dd-MM-yyyy"), textFont));

            // Agrega ambas celdas a la tabla
            empresaTable.AddCell(empresaInfoCell);
            empresaTable.AddCell(fechaPagoCell);

            // Agrega la tabla al documento
            doc.Add(empresaTable);


            doc.Add(new Paragraph("RECIBO DE PAGO", titleFont) { Alignment = Element.ALIGN_CENTER });
            doc.Add(new Paragraph(" "));

            // Información del usuario (alineada a la izquierda)
            PdfPTable infoTable = new PdfPTable(2);
            infoTable.WidthPercentage = 100;
            float[] widths = new float[] { 70f, 30f }; // Ajusta las proporciones de ancho
            infoTable.SetWidths(widths);

            // Celdas de la información del usuario (Nombre, RFC, NSS, DPTO)
            PdfPCell userInfoCell = new PdfPCell();
            userInfoCell.Border = PdfPCell.NO_BORDER;

            userInfoCell.AddElement(new Paragraph($"Nombre: {payrollRecord.Empleado}", textFont));
            userInfoCell.AddElement(new Paragraph($"RFC: {payrollRecord.RFCEmpleado}", textFont));
            userInfoCell.AddElement(new Paragraph($"NSS: {payrollRecord.NumeroIMSS}", textFont));
            userInfoCell.AddElement(new Paragraph($"DPTO: {payrollRecord.Departamento}", textFont));
            doc.Add(new Paragraph(" "));

            // Celdas de la información del salario (Salario Diario y Días Pagados)
            PdfPCell salaryInfoCell = new PdfPCell();
            salaryInfoCell.Border = PdfPCell.NO_BORDER;
            salaryInfoCell.HorizontalAlignment = Element.ALIGN_RIGHT;

            salaryInfoCell.AddElement(new Paragraph($"SALARIO DIARIO: ${payrollRecord.SalarioDiario:0.00}", textFont));
            salaryInfoCell.AddElement(new Paragraph($"DIAS PAGADOS: {payrollRecord.DiasPagados}", textFont));
            salaryInfoCell.AddElement(new Paragraph($"PERIODO DE PAGO: {payrollRecord.PeriodoPago}", textFont));


            // Agrega las celdas a la tabla
            infoTable.AddCell(userInfoCell);
            infoTable.AddCell(salaryInfoCell);

            // Agrega la tabla al documento
            doc.Add(infoTable);
            doc.Add(new Paragraph(" "));

            PdfPTable percepcionesYDeduccionesTable = new PdfPTable(4);
            percepcionesYDeduccionesTable.WidthPercentage = 100;
            float[] columnWidths = new float[] { 2f, 1f, 2f, 1f };
            percepcionesYDeduccionesTable.SetWidths(columnWidths);

            PdfPCell percepcionCell = CreateCell("PERCEPCIONES", textFont, PdfPCell.BOTTOM_BORDER);
            PdfPCell deduccionCell = CreateCell("DEDUCCIONES", textFont, PdfPCell.BOTTOM_BORDER);

            PdfPCell[] headerCells = new PdfPCell[]
            {
        percepcionCell,
        CreateCell("", textFont, PdfPCell.BOTTOM_BORDER),
        deduccionCell,
        CreateCell("", textFont, PdfPCell.BOTTOM_BORDER)
            };

            foreach (var cell in headerCells)
            {
                percepcionesYDeduccionesTable.AddCell(cell);
            }

            int maxRows = Math.Max(payrollRecord.Percepciones.Count, payrollRecord.Deducciones.Count);

            for (int i = 0; i < maxRows; i++)
            {
                if (i < payrollRecord.Percepciones.Count)
                {
                    percepcionesYDeduccionesTable.AddCell(CreateCell(payrollRecord.Percepciones[i].Concepto, textFont, PdfPCell.NO_BORDER));
                    percepcionesYDeduccionesTable.AddCell(CreateCell(payrollRecord.Percepciones[i].Importe.ToString("0.00"), textFont, PdfPCell.NO_BORDER));
                }
                else
                {
                    percepcionesYDeduccionesTable.AddCell(CreateCell("", textFont, PdfPCell.NO_BORDER));
                    percepcionesYDeduccionesTable.AddCell(CreateCell("", textFont, PdfPCell.NO_BORDER));
                }

                if (i < payrollRecord.Deducciones.Count)
                {
                    percepcionesYDeduccionesTable.AddCell(CreateCell(payrollRecord.Deducciones[i].Concepto, textFont, PdfPCell.NO_BORDER));
                    percepcionesYDeduccionesTable.AddCell(CreateCell(payrollRecord.Deducciones[i].Importe.ToString("0.00"), textFont, PdfPCell.NO_BORDER));
                }
                else
                {
                    percepcionesYDeduccionesTable.AddCell(CreateCell("", textFont, PdfPCell.NO_BORDER));
                    percepcionesYDeduccionesTable.AddCell(CreateCell("", textFont, PdfPCell.NO_BORDER));
                }
            }

            doc.Add(percepcionesYDeduccionesTable);

            PdfPTable totalTable = new PdfPTable(4);
            totalTable.WidthPercentage = 100;
            totalTable.SetWidths(columnWidths);

            totalTable.AddCell(CreateCell("TOTAL PERCEPCIONES:", textFont, PdfPCell.TOP_BORDER));
            totalTable.AddCell(CreateCell(payrollRecord.TotalPercepciones.ToString("0.00"), textFont, PdfPCell.TOP_BORDER));
            totalTable.AddCell(CreateCell("TOTAL DEDUCCIONES:", textFont, PdfPCell.TOP_BORDER));
            totalTable.AddCell(CreateCell(payrollRecord.TotalDeducciones.ToString("0.00"), textFont, PdfPCell.TOP_BORDER));

            totalTable.AddCell(CreateCell("", textFont, PdfPCell.NO_BORDER));
            totalTable.AddCell(CreateCell("", textFont, PdfPCell.NO_BORDER));
            totalTable.AddCell(CreateCell("NETO A PAGAR:", textFont, PdfPCell.NO_BORDER));
            totalTable.AddCell(CreateCell(payrollRecord.TotalNeto.ToString("0.00"), textFont, PdfPCell.NO_BORDER));

            doc.Add(totalTable);
            doc.Add(new Paragraph($"****{ConvertirNumeroALetras(payrollRecord.TotalNeto)}****", textFont));
            doc.Add(new Paragraph(" "));

            PdfPTable firmaTable = new PdfPTable(2);
            firmaTable.WidthPercentage = 100;
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));

            doc.Add(new Paragraph(" "));

            PdfPCell avisoCell = CreateCell(
                "Recibí de conformidad las prestaciones correspondientes al periodo que se indica arriba y que liquida totalmente hasta esta fecha a mi salario ordinario, salario de compensación y demás prestaciones, entendiendo que las deducciones tanto legales como de carácter privado se han aplicado a cubrir los adeudos respectivos.",
                smallTextFont,
                PdfPCell.NO_BORDER
            );

            // Justificar el texto
            avisoCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;

            firmaTable.AddCell(avisoCell);
            PdfPCell firmaCell = CreateCell(
                "Firma: __________________________________________________________",
                textFont,
                PdfPCell.NO_BORDER
            );

            // Centrar el texto en la celda
            firmaCell.HorizontalAlignment = Element.ALIGN_CENTER;

            firmaTable.AddCell(firmaCell);
            doc.Add(firmaTable);
            doc.Close();

            stream.Position = 0;
            return File(stream, "application/pdf", $"Nomina_{payrollRecord.Empleado}.pdf");
        }

        // Método para crear celdas con formato y borde específico
        private PdfPCell CreateCell(string text, iTextSharp.text.Font font, int border)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, font))
            {
                Padding = 8,
                HorizontalAlignment = Element.ALIGN_LEFT,
                Border = border
            };
            return cell;
        }

        private string ConvertirNumeroALetras(double numero)
        {
            if (numero == 0)
                return "CERO PESOS 00/100 M.N.";

            string decimales = ((int)((numero - Math.Floor(numero)) * 100)).ToString("00");
            long entero = (long)Math.Floor(numero);
            string letras = ConvertirNumeroALetras(entero);

            return $"{letras} PESOS {decimales}/100 M.N.";
        }

        private string ConvertirNumeroALetras(long numero)
        {
            string[] unidades = { "", "UNO", "DOS", "TRES", "CUATRO", "CINCO", "SEIS", "SIETE", "OCHO", "NUEVE" };
            string[] decenas = { "", "DIEZ", "VEINTE", "TREINTA", "CUARENTA", "CINCUENTA", "SESENTA", "SETENTA", "OCHENTA", "NOVENTA" };
            string[] centenas = { "", "CIENTO", "DOSCIENTOS", "TRESCIENTOS", "CUATROCIENTOS", "QUINIENTOS", "SEISCIENTOS", "SETECIENTOS", "OCHOCIENTOS", "NOVECIENTOS" };

            if (numero == 100)
                return "CIEN";

            if (numero < 10)
                return unidades[numero];

            if (numero < 20)
            {
                if (numero == 10) return "DIEZ";
                if (numero == 11) return "ONCE";
                if (numero == 12) return "DOCE";
                if (numero == 13) return "TRECE";
                if (numero == 14) return "CATORCE";
                if (numero == 15) return "QUINCE";
                return "DIECI" + unidades[numero - 10];
            }

            if (numero < 30)
                return numero == 20 ? "VEINTE" : "VEINTI" + unidades[numero - 20];

            if (numero < 100)
                return decenas[numero / 10] + (numero % 10 > 0 ? " Y " + unidades[numero % 10] : "");

            if (numero < 1000)
                return centenas[numero / 100] + (numero % 100 > 0 ? " " + ConvertirNumeroALetras(numero % 100) : "");

            if (numero < 1000000)
            {
                string miles = (numero / 1000 == 1 ? "" : ConvertirNumeroALetras(numero / 1000)) + " MIL";
                return miles + (numero % 1000 > 0 ? " " + ConvertirNumeroALetras(numero % 1000) : "");
            }

            if (numero < 1000000000000)
            {
                string millones = (numero / 1000000 == 1 ? "UN MILLÓN" : ConvertirNumeroALetras(numero / 1000000) + " MILLONES");
                return millones + (numero % 1000000 > 0 ? " " + ConvertirNumeroALetras(numero % 1000000) : "");
            }

            return "";
        }


    }
}
