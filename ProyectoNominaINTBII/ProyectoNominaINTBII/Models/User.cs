using System;
using System.Collections.Generic;

namespace ProyectoNominaINTBII.Models;

public partial class User
{
    public int Id { get; set; }

    public int? Username { get; set; }

    public string Nombre { get; set; } = null!;

    public int? Correo { get; set; }

    public string Password { get; set; } = null!;
}
