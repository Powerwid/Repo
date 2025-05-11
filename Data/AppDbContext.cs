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
            // Configurar nombres de tablas según la base de datos
            modelBuilder.Entity<Carrito>().ToTable("Carrito");
            modelBuilder.Entity<Categoria>().ToTable("Categoria");
            modelBuilder.Entity<Clientes>().ToTable("Clientes");
            modelBuilder.Entity<Compras>().ToTable("Compras");
            modelBuilder.Entity<Comprobantes>().ToTable("Comprobantes");
            modelBuilder.Entity<ComprobantesVentas>().ToTable("ComprobantesVentas");
            modelBuilder.Entity<DetalleCompra>().ToTable("DetalleCompra");
            modelBuilder.Entity<DetalleVentas>().ToTable("DetalleVentas");
            modelBuilder.Entity<MovimientoInventario>().ToTable("MovimientoInventario");
            modelBuilder.Entity<Pagos>().ToTable("Pagos");
            modelBuilder.Entity<Producto>().ToTable("Producto");
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Ventas>().ToTable("Ventas");

            // Configurar precisión y escala para propiedades decimal
            modelBuilder.Entity<Clientes>()
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

            // Configurar relaciones
            modelBuilder.Entity<Ventas>()
                .HasOne(v => v.usuario)
                .WithMany()
                .HasForeignKey(v => v.usuario_id_usuario);

            modelBuilder.Entity<Ventas>()
                .HasOne(v => v.cliente)
                .WithMany()
                .HasForeignKey(v => v.clientes_id_cliente);

            modelBuilder.Entity<Pagos>()
                .HasOne(p => p.venta)
                .WithMany(v => v.Pagos)
                .HasForeignKey(p => p.ventas_id_venta);

            modelBuilder.Entity<DetalleVentas>()
                .HasOne(dv => dv.venta)
                .WithMany(v => v.DetalleVentas)
                .HasForeignKey(dv => dv.ventas_id_venta);

            modelBuilder.Entity<DetalleVentas>()
                .HasOne(dv => dv.producto)
                .WithMany()
                .HasForeignKey(dv => dv.producto_id_producto);

            modelBuilder.Entity<DetalleCompra>()
                .HasOne(dc => dc.compra)
                .WithMany(c => c.DetalleCompra)
                .HasForeignKey(dc => dc.compras_id_compra);

            modelBuilder.Entity<DetalleCompra>()
                .HasOne(dc => dc.producto)
                .WithMany(p => p.DetalleCompra)
                .HasForeignKey(dc => dc.producto_id_producto);

            modelBuilder.Entity<MovimientoInventario>()
                .HasOne(m => m.producto)
                .WithMany()
                .HasForeignKey(m => m.producto_id_producto);

            modelBuilder.Entity<ComprobantesVentas>()
                .HasOne(cv => cv.venta)
                .WithMany()
                .HasForeignKey(cv => cv.ventas_id_venta);

            modelBuilder.Entity<ComprobantesVentas>()
                .HasOne(cv => cv.comprobante)
                .WithMany()
                .HasForeignKey(cv => cv.comprobantes_id_comprobante);

            modelBuilder.Entity<Compras>()
                .HasOne(c => c.cliente)
                .WithMany()
                .HasForeignKey(c => c.cliente_id_cliente);
        }
    }
}