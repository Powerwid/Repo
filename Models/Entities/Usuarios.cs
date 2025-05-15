using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaVentas.Models.Entities
{
    public class Usuarios
    {
        [Key]
        public int id_usuario { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public string? correo { get; set; }
        public string? usuario { get; set; }
        public string? contraseña { get; set; }
        public string? rol { get; set; }
        public string? estado { get; set; }

    }
}
