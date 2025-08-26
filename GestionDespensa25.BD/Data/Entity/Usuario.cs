using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDespensa25.BD.Data.Entity
{
    [Index(nameof(NombreUsuario), nameof(Clave), Name ="Usuario_Clave_NombreUsuario", IsUnique =false)]
    public class Usuario : EntityBase
    {

        [Required(ErrorMessage = "El Nombre Usuario es obligatorio")]
        [MaxLength(50, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string  NombreUsuario { get; set; }

        [Required(ErrorMessage = "La Clave es obligatorio")]
        [MaxLength(8, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Clave { get; set; }
        //public string Rol  { get; set; }
        public List<Caja> Cajas { get; set; }
        public List<Venta> Ventas { get; set; }
    }
}
