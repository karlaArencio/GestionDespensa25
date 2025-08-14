using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDespensa25.BD.Data.Entity
{
    [Index(nameof(ProductoId), Name = "ProductoProveedor_UQ", IsUnique = true)]
    public class ProductoProveedor : EntityBase
    {
        [Required(ErrorMessage = "El producto es obligatorio,")]
   
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        [Required(ErrorMessage = "El Proveedor es obligatorio,")]
        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }
    }
}
