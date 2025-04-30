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
        public int id_comprobante_venta { get; set; }
        public int ventas_id_venta { get; set; }
        public int comprobantes_id_comprobante { get; set; }

        [ForeignKey("ventas_id_venta")]
        public Ventas venta { get; set; }

        [ForeignKey("comprobantes_id_comprobante")]
        public Comprobantes comprobante { get; set; }
    }
}