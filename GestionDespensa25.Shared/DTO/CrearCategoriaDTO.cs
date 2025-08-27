using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDespensa25.Shared.DTO
{
   
    public class CrearCategoriaDTO
    {
        [Required(ErrorMessage = "El NombreCategoria del producto es obligatorio,")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1} ,")]
        public string NombreCategoria { get; set; }
    }
}
