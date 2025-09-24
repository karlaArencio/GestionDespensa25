using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDespensa25.BD.Data.Entity
{
    
    [Index(nameof(CompraProveedorId), nameof(ProductoId), Name = "DetalleCompraProveedor_UQ", IsUnique = true)]
    public class DetalleCompraProveedor : EntityBase
    {
        [Required(ErrorMessage = "La cantidad es obligatoria")]
        public decimal Cantidad { get; set; } //Decimal si permite fracciones

        [Required(ErrorMessage = "El precio unitario es obligatorio")]
        public decimal PrecioUnitario { get; set; }

        [Required(ErrorMessage = "La Compra Proveedor es obligatoria")]
        public int CompraProveedorId { get; set; }
        public CompraProveedor CompraProveedor { get; set; }

        [Required(ErrorMessage = "El producto es obligatorio")]
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
            
    }
}
