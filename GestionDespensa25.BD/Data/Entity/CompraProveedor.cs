using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionDespensa25.BD.Data.Entity
{
    [Index(nameof(ProveedorId), nameof(FechaCompra), Name = "CompraProveedor_UQ", IsUnique = true)]
    public class CompraProveedor : EntityBase
    {
        [Required(ErrorMessage = "La FechaCompra es obligatorio,")]
        [MaxLength(10, ErrorMessage = "Maximo número de caracteres {1} ,")]
        public string FechaCompra { get; set; }

        [Required(ErrorMessage = "La observación es obligatorio,")]
        [MaxLength(150, ErrorMessage = "Maximo número de caracteres {1} ,")]
        public string Observaciones { get; set; }

        [Required(ErrorMessage = "El total es obligatorio,")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1} ,")]
        public string Total { get; set; }

        [Required(ErrorMessage = "El Proveedor es obligatorio,")]
        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }

        public List<DetalleCompraProveedor> DetalleCompraProveedores { get; set; }
    }
}
