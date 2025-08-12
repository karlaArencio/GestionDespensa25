using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDespensa25.BD.Data.Entity
{
    public class Caja : EntityBase
    {
        public string FechaApertura { get; set; }
        public string FechaCierre { get; set; }
        public decimal MontoInicial { get; set; }
        public decimal MontoFinal { get; set; }
        public string Estado { get; set; } //abierta, cerrada, etc.
    }
}
