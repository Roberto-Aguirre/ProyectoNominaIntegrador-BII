namespace ProyectoNominaINTBII.Models
{
    public class BaseCotizacion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public char Estatus { get; set; }
        public virtual Trabajador? Trabajador { get; set; }

    }
}
