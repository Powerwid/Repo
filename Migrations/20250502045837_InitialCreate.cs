using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaVentas.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    id_categoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.id_categoria);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id_cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_venta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    monto_total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id_cliente);
                });

            migrationBuilder.CreateTable(
                name: "Comprobantes",
                columns: table => new
                {
                    id_comprobante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo_comprobante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nro_comprobante = table.Column<int>(type: "int", nullable: false),
                    fecha_emision = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comprobantes", x => x.id_comprobante);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    id_producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoria_id_categoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.id_producto);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria_categoria_id_categoria",
                        column: x => x.categoria_id_categoria,
                        principalTable: "Categoria",
                        principalColumn: "id_categoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    id_compra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario_id_usuario = table.Column<int>(type: "int", nullable: false),
                    fecha_compra = table.Column<DateTime>(type: "datetime2", nullable: true),
                    monto_total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.id_compra);
                    table.ForeignKey(
                        name: "FK_Compras_Usuario_usuario_id_usuario",
                        column: x => x.usuario_id_usuario,
                        principalTable: "Usuario",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    id_venta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario_id_usuario = table.Column<int>(type: "int", nullable: false),
                    clientes_id_cliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.id_venta);
                    table.ForeignKey(
                        name: "FK_Ventas_Clientes_clientes_id_cliente",
                        column: x => x.clientes_id_cliente,
                        principalTable: "Clientes",
                        principalColumn: "id_cliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ventas_Usuario_usuario_id_usuario",
                        column: x => x.usuario_id_usuario,
                        principalTable: "Usuario",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    id_carrito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientes_id_cliente = table.Column<int>(type: "int", nullable: false),
                    producto_id_producto = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    fecha_agregado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrito", x => x.id_carrito);
                    table.ForeignKey(
                        name: "FK_Carrito_Clientes_clientes_id_cliente",
                        column: x => x.clientes_id_cliente,
                        principalTable: "Clientes",
                        principalColumn: "id_cliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carrito_Producto_producto_id_producto",
                        column: x => x.producto_id_producto,
                        principalTable: "Producto",
                        principalColumn: "id_producto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovimientoInventario",
                columns: table => new
                {
                    id_movimiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    producto_id_producto = table.Column<int>(type: "int", nullable: false),
                    tipo_movimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    fecha_movimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    motivo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientoInventario", x => x.id_movimiento);
                    table.ForeignKey(
                        name: "FK_MovimientoInventario_Producto_producto_id_producto",
                        column: x => x.producto_id_producto,
                        principalTable: "Producto",
                        principalColumn: "id_producto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleCompra",
                columns: table => new
                {
                    id_detalle_compra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    compras_id_compra = table.Column<int>(type: "int", nullable: false),
                    producto_id_producto = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio_unitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    metodo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_devolucion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleCompra", x => x.id_detalle_compra);
                    table.ForeignKey(
                        name: "FK_DetalleCompra_Compras_compras_id_compra",
                        column: x => x.compras_id_compra,
                        principalTable: "Compras",
                        principalColumn: "id_compra",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleCompra_Producto_producto_id_producto",
                        column: x => x.producto_id_producto,
                        principalTable: "Producto",
                        principalColumn: "id_producto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComprobantesVentas",
                columns: table => new
                {
                    id_comprobante_venta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ventas_id_venta = table.Column<int>(type: "int", nullable: false),
                    comprobantes_id_comprobante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprobantesVentas", x => x.id_comprobante_venta);
                    table.ForeignKey(
                        name: "FK_ComprobantesVentas_Comprobantes_comprobantes_id_comprobante",
                        column: x => x.comprobantes_id_comprobante,
                        principalTable: "Comprobantes",
                        principalColumn: "id_comprobante",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComprobantesVentas_Ventas_ventas_id_venta",
                        column: x => x.ventas_id_venta,
                        principalTable: "Ventas",
                        principalColumn: "id_venta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleVentas",
                columns: table => new
                {
                    id_detalle_venta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ventas_id_venta = table.Column<int>(type: "int", nullable: false),
                    producto_id_producto = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio_unitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleVentas", x => x.id_detalle_venta);
                    table.ForeignKey(
                        name: "FK_DetalleVentas_Producto_producto_id_producto",
                        column: x => x.producto_id_producto,
                        principalTable: "Producto",
                        principalColumn: "id_producto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleVentas_Ventas_ventas_id_venta",
                        column: x => x.ventas_id_venta,
                        principalTable: "Ventas",
                        principalColumn: "id_venta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    id_pago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ventas_id_venta = table.Column<int>(type: "int", nullable: false),
                    metodo_pago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    monto_pagado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fecha_pago = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.id_pago);
                    table.ForeignKey(
                        name: "FK_Pagos_Ventas_ventas_id_venta",
                        column: x => x.ventas_id_venta,
                        principalTable: "Ventas",
                        principalColumn: "id_venta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_clientes_id_cliente",
                table: "Carrito",
                column: "clientes_id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_producto_id_producto",
                table: "Carrito",
                column: "producto_id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_usuario_id_usuario",
                table: "Compras",
                column: "usuario_id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_ComprobantesVentas_comprobantes_id_comprobante",
                table: "ComprobantesVentas",
                column: "comprobantes_id_comprobante");

            migrationBuilder.CreateIndex(
                name: "IX_ComprobantesVentas_ventas_id_venta",
                table: "ComprobantesVentas",
                column: "ventas_id_venta");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompra_compras_id_compra",
                table: "DetalleCompra",
                column: "compras_id_compra");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompra_producto_id_producto",
                table: "DetalleCompra",
                column: "producto_id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVentas_producto_id_producto",
                table: "DetalleVentas",
                column: "producto_id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVentas_ventas_id_venta",
                table: "DetalleVentas",
                column: "ventas_id_venta");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoInventario_producto_id_producto",
                table: "MovimientoInventario",
                column: "producto_id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_ventas_id_venta",
                table: "Pagos",
                column: "ventas_id_venta");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_categoria_id_categoria",
                table: "Producto",
                column: "categoria_id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_clientes_id_cliente",
                table: "Ventas",
                column: "clientes_id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_usuario_id_usuario",
                table: "Ventas",
                column: "usuario_id_usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carrito");

            migrationBuilder.DropTable(
                name: "ComprobantesVentas");

            migrationBuilder.DropTable(
                name: "DetalleCompra");

            migrationBuilder.DropTable(
                name: "DetalleVentas");

            migrationBuilder.DropTable(
                name: "MovimientoInventario");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Comprobantes");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
