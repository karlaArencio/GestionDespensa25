using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDespensa25.BD.Data.Entity
{
    [Index(nameof(CategoriaId), nameof(Nombre), Name = "Producto_UQ",IsUnique =true)]
    
    public class Producto : EntityBase
    {
        [Required(ErrorMessage = "El nombre del producto es obligatorio,")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1} ,")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El StockActual es obligatorio,")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock actual debe ser un número positivo")]
        public int StockActual { get; set; }

        [Required(ErrorMessage = "El StockMinimo es obligatorio,")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock mínimo debe ser un número positivo")]
        public int StockMinimo { get; set; }

        [Required(ErrorMessage = "El PrecioCosto es obligatorio,")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio costo debe ser mayor a 0")]
        public decimal PrecioCosto { get; set; }

        [Required(ErrorMessage = "El PorcentajeGanancia es obligatorio,")]
        [Range(0, 100, ErrorMessage = "El porcentaje debe estar entre 0 y 100")]
        public decimal PorcentajeGanancia { get; set; }

        [Required(ErrorMessage = "El PrecioVenta es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio venta debe ser mayor a 0")]
        public decimal PrecioVenta { get; set; }

        [Required(ErrorMessage = "El Estado es obligatorio")]
        
        public bool Estado { get; set; }

        [Required(ErrorMessage = "La categoria del producto es obligatorio,")]
        public int CategoriaId { get; set;  }
        public Categoria Categoria { get; set; } = null!;

        public List<ProductoProveedor> ProductoProveedores { get; set; } = new List<ProductoProveedor>();
        public List<DetalleVenta> DetalleVentas { get; set; } = new List<DetalleVenta>();
        public List<DetalleCompraProveedor> DetalleCompraProveedores { get; set; } = new List<DetalleCompraProveedor>();
    }
}
