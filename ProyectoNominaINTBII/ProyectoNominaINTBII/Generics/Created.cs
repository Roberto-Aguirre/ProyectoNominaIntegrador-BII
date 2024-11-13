namespace ProyectoNominaINTBII.Generics
{
    public class Created
    {
        public int code { get; set; }
        public string message { get; set; }

        public Created()
        {
            this.code = 201;
            this.message = "Creado Satisfactoriamente";
        }
    }


}
