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
        public int usuario_id_usuario { get; set; }
        public DateTime? fecha_compra { get; set; }
        public decimal monto_total { get; set; }
        public string estado { get; set; }

        [ForeignKey("usuario_id_usuario")]
        public Usuario usuario { get; set; }
    }
}
