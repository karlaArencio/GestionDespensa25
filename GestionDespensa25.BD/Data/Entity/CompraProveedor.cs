using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDespensa25.BD.Data.Entity
{
    public class CompraProveedor : EntityBase
    {
        public string FechaCompra { get; set; }
        public string Observaciones { get; set; }
        public string Total { get; set; }
        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }
    }
}
