namespace SistemaNomina.Models
{
    public class UserModel
    {
        public int Id { get; set; }  // ID del usuario
        public string NumeroEmpleado { get; set; }  // Número de empleado
        public string Nombre { get; set; }  // Nombre del empleado
        public string RFC { get; set; }  // RFC del empleado
        public string CURP { get; set; }  // CURP del empleado
        public string NoIMSS { get; set; }  // Número de IMSS
        public DateTime FechaInicio { get; set; }  // Fecha de inicio de relación laboral
        public string Puesto { get; set; }  // Puesto del empleado
        public string Departamento { get; set; }  // Departamento del empleado
        public string Regimen { get; set; }  // Régimen del empleado
        public string TipoJornada { get; set; }  // Tipo de jornada laboral
        public decimal SBC { get; set; }  // Salario base de cotización
        public decimal SDI { get; set; }  // Salario diario integrado
        public decimal SalarioDiario { get; set; }  // Salario diario del empleado
        public int Ejercicio { get; set; }  // Ejercicio fiscal
        public string Folio { get; set; }  // Folio del recibo
        public DateTime PeriodoPago { get; set; }  // Período de pago
        public DateTime FechaPago { get; set; }  // Fecha de pago
        public string Periodicidad { get; set; }  // Periodicidad de pago (e.g., mensual)
        public int DiasPagados { get; set; }  // Días pagados en el período
        public int Faltas { get; set; }  // Número de faltas

        // Propiedades agregadas para autenticación
        public string Username { get; set; }  // Nombre de usuario para login
        public string Password { get; set; }  // Contraseña del usuario
        public string Role { get; set; }  // Rol del usuario (Admin o User)
    }
}
