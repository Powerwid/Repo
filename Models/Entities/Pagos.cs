using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentas.Models.Entities
{
    public class Pagos
    {
        [Key]
        public int IdPago { get; set; }
        public int VentasIdVenta { get; set; }
        public string MetodoPago { get; set; }
        public decimal MontoPagado { get; set; }
        public DateTime? FechaPago { get; set; }

        [ForeignKey("VentasIdVenta")]
        public Ventas Venta { get; set; }
    }
}