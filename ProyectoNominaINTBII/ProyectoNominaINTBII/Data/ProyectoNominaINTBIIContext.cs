using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoNominaINTBII.Models;

namespace ProyectoNominaINTBII.Data
{
    public class ProyectoNominaINTBIIContext : DbContext
    {
        public ProyectoNominaINTBIIContext (DbContextOptions<ProyectoNominaINTBIIContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoNominaINTBII.Models.BaseCotizacion> BaseCotizacion { get; set; } = default!;
    }
}
