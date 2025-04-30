using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentas.Models.Entities
{
    public class ComprobantesVentas
    {
        [Key]
        public int IdComprobanteVenta { get; set; }
        public int VentasIdVenta { get; set; }
        public int ComprobantesIdComprobante { get; set; }

        [ForeignKey("VentasIdVenta")]
        public Ventas Venta { get; set; }

        [ForeignKey("ComprobantesIdComprobante")]
        public Comprobantes Comprobante { get; set; }
    }
}