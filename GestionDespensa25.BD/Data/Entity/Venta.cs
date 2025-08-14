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
        [Required(ErrorMessage = "La Fecha de Venta es obligatorio")]
        [MaxLength(10, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Fecha { get; set; }

        [Required(ErrorMessage = "El tipo de pago de Venta es obligatorio")]
        [MaxLength(150, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string TipoPago { get; set; }//efectivo, tarjeta, transferencia.

        [Required(ErrorMessage = "La Estado de Venta es obligatorio")]
        [MaxLength(150, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Estado { get; set; } //pendiente, pagado, anulado.

        [Required(ErrorMessage = "El sub total de Venta es obligatorio")]
        [MaxLength(150, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string SubTotal { get; set; }
        [Required(ErrorMessage = "El impuesto de Venta es obligatorio")]
        [MaxLength(150, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Impuesto { get; set; }
        [Required(ErrorMessage = "El total de Venta es obligatorio")]
        [MaxLength(150, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Total { get; set; }
        [Required(ErrorMessage = "El monto pagado de venta es obligatorio")]
        [MaxLength(150, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string MontoPagado { get; set; }
        [Required(ErrorMessage = "El saldo pendiente de venta es obligatorio")]
        [MaxLength(150, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string SaldoPendiente { get; set; }

        [Required(ErrorMessage = "El Cliente es obligatorio")]
        public int ClienteId { get; set; } //clave foránea
        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = "La caja es obligatorio")]
        public int CajaId { get; set; }
        public Caja Caja { get; set; } 
        
        public List<DetalleVenta> DetalleVentas { get; set; } //Relacion 1:N una venta puede tener muchos detalles de ventas
    }
}
