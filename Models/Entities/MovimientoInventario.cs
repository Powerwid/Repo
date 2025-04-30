using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentas.Models.Entities
{
    public class MovimientoInventario
    {
        [Key]
        public int id_movimiento { get; set; }
        public int producto_id_producto { get; set; }
        public string tipo_movimiento { get; set; }
        public int cantidad { get; set; }
        public DateTime? fecha_movimiento { get; set; }
        public string motivo { get; set; }

        [ForeignKey("producto_id_producto")]
        public Producto producto { get; set; }
    }
}