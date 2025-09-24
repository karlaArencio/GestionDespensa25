using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDespensa25.BD.Data.Entity
{
    [Index(nameof(CajaId), nameof(FechaHora), Name = "DetalleCaja_IDX")]
    public class DetalleCaja : EntityBase
    {
        [Required(ErrorMessage = "La FechaHora de DetalleCaja es obligatorio")]
        public DateTime FechaHora { get; set; }

        [Required(ErrorMessage = "El Tipo de movimiento de DetalleCaja es obligatorio")]
        [MaxLength(150, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string TipoMovimiento { get; set; } //ingreso, egreso.

        [Required(ErrorMessage = "El monto es obligatorio")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "El Concepto de DetalleCaja es obligatorio")]
        [MaxLength(200, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string Concepto { get; set; }

        [Required(ErrorMessage = "La Referencia de DetalleCaja es obligatoria")]
        [MaxLength(200, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string Referencia { get; set; }//venta, gasto, etc.

        [Required(ErrorMessage ="La Caja es obligatorio")]
        public int CajaId { get; set; }
        public Caja Caja { get; set; }

    }
}
