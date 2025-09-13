using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDespensa25.Shared.DTO
{
    public class CrearCateg_ProductoDTO
    {
        [Required(ErrorMessage = "El Nombre de Categoria  es obligatorio,")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1} ,")]
        public string NombreCategoriaCateg { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio,")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1} ,")]
        public string NombreProducto { get; set; }

        [Required(ErrorMessage = "El StockActual es obligatorio,")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock actual debe ser un número positivo")]
        public string StockActualProducto { get; set; }

        [Required(ErrorMessage = "El StockMinimo es obligatorio,")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock mínimo debe ser un número positivo")]
        public string StockMinimoProducto { get; set; }

        [Required(ErrorMessage = "El PrecioCosto es obligatorio,")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio costo debe ser mayor a 0")]
        public string PrecioCostoProducto { get; set; }

        [Required(ErrorMessage = "El PorcentajeGanancia es obligatorio,")]
        [Range(0, 100, ErrorMessage = "El porcentaje debe estar entre 0 y 100")]
        public string PorcentajeGananciaProducto { get; set; }

        [Required(ErrorMessage = "El PrecioVenta es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio venta debe ser mayor a 0")]
        public string PrecioVentaProducto { get; set; }

        [Required(ErrorMessage = "El Estado es obligatorio")]
        public string EstadoProducto { get; set; }
    }
}
