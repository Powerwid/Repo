using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaVentas.Models.Entities
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string UsuarioNombre { get; set; } // Renombrado para evitar conflicto con el nombre de la clase
        public string Contraseña { get; set; }
        public string Rol { get; set; }
        public string Estado { get; set; }
    }
}
