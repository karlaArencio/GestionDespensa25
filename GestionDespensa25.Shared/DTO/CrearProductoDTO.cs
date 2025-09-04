using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDespensa25.Shared.DTO
{
    public class CrearProductoDTO
    {
        [Required(ErrorMessage = "El nombre del producto es obligatorio,")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1} ,")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El StockActual es obligatorio,")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1} ,")]
        public string StockActual { get; set; }

        [Required(ErrorMessage = "El StockMinimo es obligatorio,")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1} ,")]
        public string StockMinimo { get; set; }

        [Required(ErrorMessage = "El PrecioCosto es obligatorio,")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1} ,")]
        public string PrecioCosto { get; set; }

        [Required(ErrorMessage = "El PorcentajeGanancia es obligatorio,")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1} ,")]
        public string PorcentajeGanancia { get; set; }

        [Required(ErrorMessage = "El PrecioVenta es obligatorio,")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1} ,")]
        public string PrecioVenta { get; set; }

        [Required(ErrorMessage = "El Estado es obligatorio,")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1} ,")]
        public string Estado { get; set; }

        
    }
}
