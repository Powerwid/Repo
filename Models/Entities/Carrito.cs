using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentas.Models.Entities
{
    public class Carrito
    {
        [Key]
        public int id_carrito { get; set; }
        public int clientes_id_cliente { get; set; }
        public int producto_id_producto { get; set; }
        public int cantidad { get; set; }
        public DateTime? fecha_agregado { get; set; }
        public string estado { get; set; }

        [ForeignKey("clientes_id_cliente")]
        public Clientes cliente { get; set; }

        [ForeignKey("producto_id_producto")]
        public Producto producto { get; set; }
    }
}