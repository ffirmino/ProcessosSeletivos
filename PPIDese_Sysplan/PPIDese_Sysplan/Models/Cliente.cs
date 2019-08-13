using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PPIDese_Sysplan.Models
{
    [Table("TBLCliente")]
    public class Cliente
    {
        [Key]
        public int IDCliente { get; set; }
        public string Nome { get; set; }
        public string Data_Nascimento { get; set; }
        public decimal Renda { get; set; }

    }
}