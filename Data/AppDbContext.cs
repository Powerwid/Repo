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
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSets para todas tus entidades
        public DbSet<Carrito> Carrito { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Compras> Compras { get; set; }
        public DbSet<Comprobantes> Comprobantes { get; set; }
        public DbSet<ComprobantesVentas> ComprobantesVentas { get; set; }
        public DbSet<DetalleCompra> DetalleCompra { get; set; }
        public DbSet<DetalleVentas> DetalleVentas { get; set; }
        public DbSet<MovimientoInventario> MovimientoInventario { get; set; }
        public DbSet<Pagos> Pagos { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Ventas> Ventas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar nombres de tablas
            modelBuilder.Entity<Carrito>().ToTable("carrito");
            modelBuilder.Entity<Categoria>().ToTable("categoria");
            modelBuilder.Entity<Clientes>().ToTable("clientes");
            modelBuilder.Entity<Compras>().ToTable("compras");
            modelBuilder.Entity<Comprobantes>().ToTable("comprobantes");
            modelBuilder.Entity<ComprobantesVentas>().ToTable("comprobantes_ventas");
            modelBuilder.Entity<DetalleCompra>().ToTable("detalle_compra");
            modelBuilder.Entity<DetalleVentas>().ToTable("detalle_ventas");
            modelBuilder.Entity<MovimientoInventario>().ToTable("movimiento_inventario");
            modelBuilder.Entity<Pagos>().ToTable("pagos");
            modelBuilder.Entity<Producto>().ToTable("producto");
            modelBuilder.Entity<Usuario>().ToTable("usuario");
            modelBuilder.Entity<Ventas>().ToTable("ventas");

            // Configurar precisión y escala para propiedades decimal
            modelBuilder.Entity<Clientes>().ToTable("Clientes")
                .Property(c => c.monto_total)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Compras>()
                .Property(c => c.monto_total)
                .HasPrecision(18, 2);

            modelBuilder.Entity<DetalleCompra>()
                .Property(dc => dc.precio_unitario)
                .HasPrecision(18, 2);

            modelBuilder.Entity<DetalleVentas>()
                .Property(dv => dv.precio_unitario)
                .HasPrecision(18, 2);

            modelBuilder.Entity<DetalleVentas>()
                .Property(dv => dv.subtotal)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Pagos>()
                .Property(p => p.monto_pagado)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Producto>()
                .Property(p => p.precio)
                .HasPrecision(18, 2);
        }
    }
}