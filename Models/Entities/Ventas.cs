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
        public int IdVenta { get; set; }
        public int UsuarioIdUsuario { get; set; }
        public int ClientesIdCliente { get; set; }

        [ForeignKey("UsuarioIdUsuario")]
        public Usuario Usuario { get; set; }

        [ForeignKey("ClientesIdCliente")]
        public Clientes Cliente { get; set; }
    }
}