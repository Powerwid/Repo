using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaVentas.Models.Entities
{
    public class Comprobantes
    {
        [Key]
        public int id_comprobante { get; set; }
        public string tipo_comprobante { get; set; }
        public int nro_comprobante { get; set; }
        public DateTime? fecha_emision { get; set; }
    }
}