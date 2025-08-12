using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDespensa25.BD.Data.Entity
{
    public class DetalleCompraProveedor : EntityBase
    {
        public string Cantidad { get; set; }
        public string PrecioUnitario { get; set; }
        public int CompraProveedorId { get; set; }
        public CompraProveedor CompraProveedor { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
            
    }
}
