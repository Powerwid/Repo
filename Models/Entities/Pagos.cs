using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentas.Models.Entities
{
    public class Pagos
    {
        [Key]
        public int id_pago { get; set; }
        public int ventas_id_venta { get; set; }
        public string metodo_pago { get; set; }
        public decimal monto_pagado { get; set; }
        public DateTime? fecha_pago { get; set; }

        [ForeignKey("ventas_id_venta")]
        public Ventas venta { get; set; }
    }
}