using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient; // Asegúrate de usar Microsoft.Data.SqlClient

namespace ProyectoNominaINTBII.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IConfiguration _configuration;

        public DashboardController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConnectionString()
        {
            var connectionString = _configuration.GetConnectionString("ProyDb2bContext");
            Console.WriteLine(connectionString); // O usa un punto de interrupción aquí para depurar
            return connectionString;
        }

        [HttpGet]
        public IActionResult GetDashboardData()
        {
            var dashboardData = new
            {
                TotalPagado = GetTotalPagado(),
                EmpleadosActivos = GetActiveEmployees(),
                NominasGeneradas = GetGeneratedPayrolls()
            };
            return Json(dashboardData);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var dashboardData = new
            {
                TotalPagado = GetTotalPagado(),
                EmpleadosActivos = GetActiveEmployees(),
                NominasGeneradas = GetGeneratedPayrolls()
            };
            return View(dashboardData);
        }

        private decimal GetTotalPagado()
        {
            using (var conn = new SqlConnection(GetConnectionString()))
            {
                string sql = "SELECT COALESCE(SUM(TotalPercepciones), 0) FROM Nomina WHERE Estatus = 'A'";
                var cmd = new SqlCommand(sql, conn);
                conn.Open();
                object result = cmd.ExecuteScalar(); 
                return Convert.ToDecimal(result);  
            }
        }

        private int GetActiveEmployees()
        {
            using (var conn = new SqlConnection(GetConnectionString()))
            {
                string sql = "SELECT COUNT(*) FROM Trabajador WHERE Estatus = 'Activo'";
                var cmd = new SqlCommand(sql, conn);
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        private int GetGeneratedPayrolls()
        {
            using (var conn = new SqlConnection(GetConnectionString()))
            {
                string sql = "SELECT COUNT(*) FROM Nomina WHERE Estatus = 'Generada'";
                var cmd = new SqlCommand(sql, conn);
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }
    }
}
