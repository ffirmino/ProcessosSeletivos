using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PPIDese_Sysplan.Models
{
    public class clienteDbInitializer : CreateDatabaseIfNotExists<clienteContexto>
    {
        protected override void Seed(clienteContexto context)
        {
            IList<Cliente> dados = new List<Cliente>();

            dados.Add(new Cliente() { Nome = "Maria Silva", Data_Nascimento = "12/01/1998 00:00:00 ", Renda = 300000 });
            dados.Add(new Cliente() { Nome = "Maria Fernanda", Data_Nascimento = "06/12/2000 00:00:00 ", Renda = 150000 });
            dados.Add(new Cliente() { Nome = "Marcos Souza", Data_Nascimento = "18/02/1978 00:00:00 ", Renda = 100000 });
            dados.Add(new Cliente() { Nome = "Sergio Santos", Data_Nascimento = "15/04/1989 00:00:00 ", Renda = 50000 });
            dados.Add(new Cliente() { Nome = "Fernanda Silva", Data_Nascimento = "06/12/2001 00:00:00 ", Renda = 140000 });
            dados.Add(new Cliente() { Nome = "Andre Costa", Data_Nascimento = "22/12/1981 00:00:00 ", Renda = 1000000 });

            foreach (Cliente valor in dados)
                context.cliente.Add(valor);

            base.Seed(context);
        }
    }
}