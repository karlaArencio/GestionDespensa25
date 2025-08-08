using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDespensa25.BD.Data.Entity
{
    public class Producto : EntityBase
    {
        public string Nombre { get; set; }
        public string StockActual { get; set; }
        public string StockMinimo { get; set; }
        public string PrecioCosto { get; set; }
        public string PorcentajeGanancia { get; set; }
        public string PrecioVenta { get; set; }
        public string Estado { get; set; }
    }
}
