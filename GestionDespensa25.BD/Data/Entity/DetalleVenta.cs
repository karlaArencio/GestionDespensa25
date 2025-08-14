using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDespensa25.BD.Data.Entity
{
    [Index(nameof(ProductoId), nameof(PrecioUnitario), Name = "DetalleVenta_UQ", IsUnique = true)]
    public class DetalleVenta : EntityBase
    {
        [Required(ErrorMessage = "El precio unitario es obligatorio")]
        [MaxLength(150, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string PrecioUnitario { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatorio")]
        [MaxLength(150, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Cantidad { get; set; }

        [Required(ErrorMessage = "El subtotal es obligatorio")]
        [MaxLength(150, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Subtotal { get; set; }

        [Required(ErrorMessage = "La Venta es obligatorio")]
     
        public int VentaId { get; set; }
        public Venta venta { get; set;  }

        [Required(ErrorMessage = "El producto es obligatorio")]
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

    }
}
