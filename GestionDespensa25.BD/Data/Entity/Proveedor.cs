using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GestionDespensa25.BD.Data.Entity
{
    [Index(nameof(Nombre), Name = "Proveedor_UQ", IsUnique = true)]
    public class Proveedor : EntityBase
    {
        [Required(ErrorMessage = "El nombre del Proveedor es obligatorio,")]
        [MaxLength(100, ErrorMessage = "Maximo número de caracteres {1} ,")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El CUIT del Proveedor es obligatorio,")]
        [MaxLength(100, ErrorMessage = "Maximo número de caracteres {1} ,")]
        public string CUIT { get; set; }
        [Required(ErrorMessage = "El Telefono del proveedor es obligatorio,")]
        [MaxLength(20, ErrorMessage = "Maximo número de caracteres {1} ,")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El mail del proveedor es obligatorio,")]
        [MaxLength(100, ErrorMessage = "Maximo número de caracteres {1} ,")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La direccion del proveedor es obligatorio,")]
        [MaxLength(100, ErrorMessage = "Maximo número de caracteres {1} ,")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El estado del proveedor es obligatorio,")]
        [MaxLength(100, ErrorMessage = "Maximo número de caracteres {1} ,")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "La FechaAlta del Proveedor es obligatorio,")]
        [MaxLength(10, ErrorMessage = "Maximo número de caracteres {1} ,")]
        public string FechaAlta { get; set; }

        
        public string Observacion { get; set; }
    }
}
