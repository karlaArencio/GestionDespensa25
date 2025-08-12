using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDespensa25.BD.Data.Entity
{
    public class Venta : EntityBase
    {
        public string Fecha { get; set; }
        public string TipoPago { get; set; }//efectivo, tarjeta, transferencia.
        public string Estado { get; set; } //pendiente, pagado, anulado.
        public string SubTotal { get; set; }
        public string Impuesto { get; set; }
        public string Total { get; set; }
        public string MontoPagado { get; set; }
        public string SaldoPendiente { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int CajaId { get; set; }
        public Caja Caja { get; set; } 
    }
}
