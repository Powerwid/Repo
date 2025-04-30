using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentas.Models.Entities
{
    public class DetalleCompra
    {
        [Key]
        public int id_detalle_compra { get; set; }
        public int compras_id_compra { get; set; }
        public int producto_id_producto { get; set; }
        public int cantidad { get; set; }
        public decimal precio_unitario { get; set; }
        public string metodo { get; set; }
        public DateTime? fecha_devolucion { get; set; }

        [ForeignKey("compras_id_compra")]
        public Compras compra { get; set; }

        [ForeignKey("producto_id_producto")]
        public Producto producto { get; set; }
    }
}