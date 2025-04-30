using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentas.Models.Entities
{
    public class Ventas
    {
        [Key]
        public int id_venta { get; set; }
        public int usuario_id_usuario { get; set; }
        public int clientes_id_cliente { get; set; }

        [ForeignKey("usuario_id_usuario")]
        public Usuario usuario { get; set; }

        [ForeignKey("clientes_id_cliente")]
        public Clientes cliente { get; set; }
    }
}