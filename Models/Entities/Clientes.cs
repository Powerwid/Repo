using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaVentas.Models.Entities
{
    public class Clientes
    {
        [Key]
        public int id_cliente { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public DateTime? fecha_venta { get; set; }
        public decimal monto_total { get; set; }
        public string? correo { get; set; }
        public string? telefono { get; set; }
        public string? direccion { get; set; }
        public string? estado { get; set; }
    }
}