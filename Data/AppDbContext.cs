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
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Comprobantes> Comprobantes { get; set; }
        public DbSet<Compras> Compras { get; set; }
        public DbSet<ComprobantesVentas> ComprobantesVentas { get; set; }
        public DbSet<Pagos> Pagos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<DetalleVentas> DetalleVentas { get; set; }
        public DbSet<DetalleCompra> DetalleCompras { get; set; }
        public DbSet<MovimientoInventario> MovimientosInventario { get; set; }
        public DbSet<Carrito> Carritos { get; set; } 

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar nombres de tablas
            modelBuilder.Entity<Usuario>().ToTable("usuario");
            modelBuilder.Entity<Clientes>().ToTable("clientes");
            modelBuilder.Entity<Ventas>().ToTable("ventas");
            modelBuilder.Entity<Comprobantes>().ToTable("comprobantes");
            modelBuilder.Entity<Compras>().ToTable("compras");
            modelBuilder.Entity<ComprobantesVentas>().ToTable("comprobantes_ventas");
            modelBuilder.Entity<Pagos>().ToTable("pagos");
            modelBuilder.Entity<Categoria>().ToTable("categoria");
            modelBuilder.Entity<Producto>().ToTable("producto");
            modelBuilder.Entity<DetalleVentas>().ToTable("detalle_ventas");
            modelBuilder.Entity<DetalleCompra>().ToTable("detalle_compra");
            modelBuilder.Entity<MovimientoInventario>().ToTable("movimiento_inventario");
            modelBuilder.Entity<Carrito>().ToTable("carrito"); 
        }
    }
}