using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDespensa25.BD.Data.Entity
{
    
    [Index(nameof(ProductoId), nameof(Cantidad), Name = "DetalleCompraProveedor_UQ", IsUnique = true)]
    public class DetalleCompraProveedor : EntityBase
    {
        [Required(ErrorMessage = "La cantidad es obligatorio,")]
        [MaxLength(150, ErrorMessage = "Maximo número de caracteres {1} ,")]
        public string Cantidad { get; set; }

        [Required(ErrorMessage = "La FechaCompra es obligatorio,")]
        [MaxLength(150, ErrorMessage = "Maximo número de caracteres {1} ,")]
        public string PrecioUnitario { get; set; }

        [Required(ErrorMessage = "La CompraProveedor es obligatorio,")]
        public int CompraProveedorId { get; set; }
        public CompraProveedor CompraProveedor { get; set; }

        [Required(ErrorMessage = "El producto es obligatorio,")]
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
            
    }
}
