using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDespensa25.BD.Data.Entity
{
    [Index(nameof(ClienteId), nameof(Fecha), Name = "Venta_UQ", IsUnique = true)]
    

    public class Venta : EntityBase
    {
        [Required(ErrorMessage = "La fecha de venta es obligatoria")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El tipo de pago de la venta es obligatorio")]
        [MaxLength(50, ErrorMessage = "Máximo número de caracteres {1}")]
        public string TipoPago { get; set; } // Efectivo, tarjeta, transferencia

        [Required(ErrorMessage = "El estado de la venta es obligatorio")]
        [MaxLength(50, ErrorMessage = "Máximo número de caracteres {1}")]
        public string Estado { get; set; } // Pendiente, pagado, anulado

        [Required(ErrorMessage = "El subtotal de la venta es obligatorio")]
        public decimal SubTotal { get; set; }

        [Required(ErrorMessage = "El impuesto de la venta es obligatorio")]
        public decimal Impuesto { get; set; }

        [Required(ErrorMessage = "El total de la venta es obligatorio")]
        public decimal Total { get; set; }

        [Required(ErrorMessage = "El monto pagado de la venta es obligatorio")]
        public decimal MontoPagado { get; set; }

        [Required(ErrorMessage = "El saldo pendiente de la venta es obligatorio")]
        public decimal SaldoPendiente { get; set; }

        [Required(ErrorMessage = "El cliente es obligatorio")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public List<DetalleVenta> DetalleVentas { get; set; } = new List<DetalleVenta>(); // 1:N
    }
}
