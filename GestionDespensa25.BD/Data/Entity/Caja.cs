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
    [Index(nameof(FechaApertura), Name = "Caja_UQ", IsUnique = true)]
    public class Caja : EntityBase
    {
        [Required(ErrorMessage = "La FechaApertura de caja es obligatorio")]
        [MaxLength(10, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string FechaApertura { get; set; }

        [Required(ErrorMessage = "La FechaCierre de caja es obligatorio")]
        [MaxLength(10, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string FechaCierre { get; set; }

        [Required(ErrorMessage = "El Monto inicial de caja es obligatorio")]
        [MaxLength(250, ErrorMessage = "Máximo número de caracteres {1}.")]
        public decimal MontoInicial { get; set; }
        [Required(ErrorMessage = "El Monto Final de caja es obligatorio")]
        [MaxLength(250, ErrorMessage = "Máximo número de caracteres {1}.")]
        public decimal MontoFinal { get; set; }

        [Required(ErrorMessage = "El Estado de caja es obligatorio")]
        [MaxLength(50, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Estado { get; set; } //abierta, cerrada, etc.

        [Required(ErrorMessage = "El usuario es obligatorio")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public List<DetalleCaja> DetalleCajas { get; set; }
        
    }
}
