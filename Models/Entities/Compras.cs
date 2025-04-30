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
        public int IdCompra { get; set; }
        public int UsuarioIdUsuario { get; set; }
        public DateTime? FechaCompra { get; set; }
        public decimal MontoTotal { get; set; }
        public string Estado { get; set; }

        [ForeignKey("UsuarioIdUsuario")]
        public Usuario Usuario { get; set; }
    }
}
