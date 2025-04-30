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
        public int IdMovimiento { get; set; }
        public int ProductoIdProducto { get; set; }
        public string TipoMovimiento { get; set; }
        public int Cantidad { get; set; }
        public DateTime? FechaMovimiento { get; set; }
        public string Motivo { get; set; }

        [ForeignKey("ProductoIdProducto")]
        public Producto Producto { get; set; }
    }
}