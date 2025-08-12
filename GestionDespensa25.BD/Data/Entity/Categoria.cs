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
    [Index(nameof(NombreCategoria), Name = "Producto_UQ", IsUnique = true)]
    public class Categoria : EntityBase
    {
        [Required(ErrorMessage = "El NombreCategoria del producto es obligatorio,")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1} ,")]
        public string NombreCategoria { get; set; }

        public List<Producto> Productos { get; set; }
    }
}
