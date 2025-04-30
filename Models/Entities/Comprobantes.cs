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
        public int IdComprobante { get; set; }
        public string TipoComprobante { get; set; }
        public int NroComprobante { get; set; }
        public DateTime? FechaEmision { get; set; }
    }
}