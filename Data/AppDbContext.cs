using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaVentas.Models.Entities;

namespace SistemaVentas.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> usuario { get; set; }
        public DbSet<Clientes> clientes { get; set; }
        public DbSet<Ventas> ventas { get; set; }
        public DbSet<Comprobantes> comprobantes { get; set; }
        public DbSet<Compras> compras { get; set; }
        public DbSet<ComprobantesVentas> comprobantes_ventas { get; set; }
        public DbSet<Pagos> pagos { get; set; }
        public DbSet<Categoria> categoria { get; set; }
        public DbSet<Producto> producto { get; set; }
        public DbSet<DetalleVentas> detalle_ventas { get; set; }
        public DbSet<DetalleCompra> detalle_compra { get; set; }
        public DbSet<MovimientoInventario> movimiento_inventario { get; set; }
        public DbSet<Carrito> carrito { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // No es necesario mapear los nombres de las tablas, ya que coinciden con los nombres de las clases
        }
    }
}