using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDespensa25.BD.Data.Entity
{
    public class DetalleCaja : EntityBase
    {
        public string FechaHora { get; set; }
        public string TipoMovimiento { get; set; } //ingreso, egreso.
        public string Monto { get; set; }
        public string Concepto { get; set; } 
        public string Referencia { get; set; }//venta, gasto, etc.
        public int CajaId { get; set; }
        public Caja Caja { get; set; }
    }
}
