using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDespensa25.BD.Data.Entity
{
    public class DetalleVenta : EntityBase
    {
        public string PrecioUnitario { get; set; }
        public string Cantidad { get; set; }
        public string Subtotal { get; set; }
        public int VentaId { get; set; }
        public Venta venta { get; set;  }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

    }
}
