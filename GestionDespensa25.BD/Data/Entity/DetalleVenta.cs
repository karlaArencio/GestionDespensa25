using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDespensa25.BD.Data.Entity
{
    [Index(nameof(VentaId), nameof(ProductoId), Name = "DetalleVenta_UQ", IsUnique = true)]
    public class DetalleVenta : EntityBase
    {
        [Required(ErrorMessage = "El precio unitario es obligatorio")]
        public decimal PrecioUnitario { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        public decimal Cantidad { get; set; }

        [Required(ErrorMessage = "El subtotal es obligatorio")]
        public decimal Subtotal { get; set; }

        [Required(ErrorMessage = "La Venta es obligatoria")]
        public int VentaId { get; set; }
        public Venta Venta { get; set;  }

        [Required(ErrorMessage = "El producto es obligatorio")]
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

    }
}
