using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentas.Models.Entities
{
    public class Compras
    {
        [Key]
        public int id_compra { get; set; }
        public int cliente_id_cliente { get; set; }
        public DateTime? fecha_compra { get; set; }
        public decimal monto_total { get; set; }
        public string estado { get; set; }

        [ForeignKey("cliente_id_cliente")]
        public Clientes cliente { get; set; }

        public List<DetalleCompra> DetalleCompra { get; set; }
    }
}
