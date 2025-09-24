using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDespensa25.BD.Data.Entity
{
    [Index(nameof(NombreUsuario), Name ="Usuario_NombreUsuario_UQ", IsUnique = true)]
    public class Usuario : EntityBase
    {

        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        [MaxLength(50, ErrorMessage = "Máximo número de caracteres {1}")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "La clave es obligatoria")]
        [MaxLength(8, ErrorMessage = "Máximo número de caracteres {1}")]
        public string Clave { get; set; }

        // Rol, cajas y ventas para futuras relaciones
        // public string Rol  { get; set; }
        // public List<Caja> Cajas { get; set; } = new List<Caja>();
        // public List<Venta> Ventas { get; set; } = new List<Venta>();
    }
}
