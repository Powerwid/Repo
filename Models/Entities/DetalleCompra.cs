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
        public int IdDetalleCompra { get; set; }
        public int ComprasIdCompra { get; set; }
        public int ProductoIdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string Metodo { get; set; }
        public DateTime? FechaDevolucion { get; set; }

        [ForeignKey("ComprasIdCompra")]
        public Compras Compra { get; set; }

        [ForeignKey("ProductoIdProducto")]
        public Producto Producto { get; set; }
    }
}