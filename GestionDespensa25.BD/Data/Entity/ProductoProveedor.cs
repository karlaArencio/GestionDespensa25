using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDespensa25.BD.Data.Entity
{
    public class ProductoProveedor : EntityBase
    {
        public string PrecioUnitario { get; set; }
        public string Cantidad { get; set; }
    }
}
