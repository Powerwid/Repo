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
        public int IdDetalleVenta { get; set; }
        public int VentasIdVenta { get; set; }
        public int ProductoIdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }

        [ForeignKey("VentasIdVenta")]
        public Ventas Venta { get; set; }

        [ForeignKey("ProductoIdProducto")]
        public Producto Producto { get; set; }
    }
}
