using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDespensa25.Shared.DTO
{
    public class CrearClienteDTO
    {
        [Required(ErrorMessage = "El nombre del cliente es obligatorio,")]
        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {1} ,")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido del cliente es obligatorio,")]
        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {1} ,")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El DNI del cliente es obligatorio,")]
        [MaxLength(11, ErrorMessage = "Máximo número de caracteres {1} ,")]
        public string DNI { get; set; }

        [Required(ErrorMessage = "El telefono del cliente es obligatorio,")]
        [MaxLength(20, ErrorMessage = "Maximo número de caracteres {1} ,")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La Direccion del cliente es obligatorio,")]
        [MaxLength(100, ErrorMessage = "Maximo número de caracteres {1} ,")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El estado del cliente es obligatorio,")]
        [MaxLength(100, ErrorMessage = "El estado del cliente es obligatorio {1},")]
        public string Estado { get; set; }


    }
}
