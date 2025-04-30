using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentas.Models.Entities
{
    public class DetalleVentas
    {
        [Key]
        public int id_detalle_venta { get; set; }
        public int ventas_id_venta { get; set; }
        public int producto_id_producto { get; set; }
        public int cantidad { get; set; }
        public decimal precio_unitario { get; set; }
        public decimal subtotal { get; set; }

        [ForeignKey("ventas_id_venta")]
        public Ventas venta { get; set; }

        [ForeignKey("producto_id_producto")]
        public Producto producto { get; set; }
    }
}
