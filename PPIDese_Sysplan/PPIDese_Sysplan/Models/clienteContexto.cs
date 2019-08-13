using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PPIDese_Sysplan.Models
{
    public class clienteContexto : DbContext
    {
        public clienteContexto()
            : base("name=PPISysplanConnectionString")
        {
            Database.SetInitializer<clienteContexto>(new clienteDbInitializer());
        }

        public DbSet<Cliente> cliente { get; set; }
    }
}