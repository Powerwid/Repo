using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVentas.Models.Entities
{
    public class Producto
    {
        [Key]
        public int id_producto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }
        public string estado { get; set; }
        public int categoria_id_categoria { get; set; }

        [ForeignKey("categoria_id_categoria")]
        public Categoria categoria { get; set; }
    }
}