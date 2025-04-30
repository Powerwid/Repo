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
        public int IdCarrito { get; set; }
        public int ClientesIdCliente { get; set; }
        public int ProductoIdProducto { get; set; }
        public int Cantidad { get; set; }
        public DateTime? FechaAgregado { get; set; }
        public string Estado { get; set; }

        [ForeignKey("ClientesIdCliente")]
        public Clientes Cliente { get; set; }

        [ForeignKey("ProductoIdProducto")]
        public Producto Producto { get; set; }
    }
}