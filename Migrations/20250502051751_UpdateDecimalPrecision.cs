using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaVentas.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDecimalPrecision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrito_Clientes_clientes_id_cliente",
                table: "Carrito");

            migrationBuilder.DropForeignKey(
                name: "FK_Carrito_Producto_producto_id_producto",
                table: "Carrito");

            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Usuario_usuario_id_usuario",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_ComprobantesVentas_Comprobantes_comprobantes_id_comprobante",
                table: "ComprobantesVentas");

            migrationBuilder.DropForeignKey(
                name: "FK_ComprobantesVentas_Ventas_ventas_id_venta",
                table: "ComprobantesVentas");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCompra_Compras_compras_id_compra",
                table: "DetalleCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCompra_Producto_producto_id_producto",
                table: "DetalleCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleVentas_Producto_producto_id_producto",
                table: "DetalleVentas");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleVentas_Ventas_ventas_id_venta",
                table: "DetalleVentas");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimientoInventario_Producto_producto_id_producto",
                table: "MovimientoInventario");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_Ventas_ventas_id_venta",
                table: "Pagos");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Categoria_categoria_id_categoria",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Clientes_clientes_id_cliente",
                table: "Ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Usuario_usuario_id_usuario",
                table: "Ventas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ventas",
                table: "Ventas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Producto",
                table: "Producto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pagos",
                table: "Pagos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comprobantes",
                table: "Comprobantes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Compras",
                table: "Compras");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carrito",
                table: "Carrito");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovimientoInventario",
                table: "MovimientoInventario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetalleVentas",
                table: "DetalleVentas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetalleCompra",
                table: "DetalleCompra");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComprobantesVentas",
                table: "ComprobantesVentas");

            migrationBuilder.RenameTable(
                name: "Ventas",
                newName: "ventas");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "usuario");

            migrationBuilder.RenameTable(
                name: "Producto",
                newName: "producto");

            migrationBuilder.RenameTable(
                name: "Pagos",
                newName: "pagos");

            migrationBuilder.RenameTable(
                name: "Comprobantes",
                newName: "comprobantes");

            migrationBuilder.RenameTable(
                name: "Compras",
                newName: "compras");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "clientes");

            migrationBuilder.RenameTable(
                name: "Categoria",
                newName: "categoria");

            migrationBuilder.RenameTable(
                name: "Carrito",
                newName: "carrito");

            migrationBuilder.RenameTable(
                name: "MovimientoInventario",
                newName: "movimiento_inventario");

            migrationBuilder.RenameTable(
                name: "DetalleVentas",
                newName: "detalle_ventas");

            migrationBuilder.RenameTable(
                name: "DetalleCompra",
                newName: "detalle_compra");

            migrationBuilder.RenameTable(
                name: "ComprobantesVentas",
                newName: "comprobantes_ventas");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_usuario_id_usuario",
                table: "ventas",
                newName: "IX_ventas_usuario_id_usuario");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_clientes_id_cliente",
                table: "ventas",
                newName: "IX_ventas_clientes_id_cliente");

            migrationBuilder.RenameIndex(
                name: "IX_Producto_categoria_id_categoria",
                table: "producto",
                newName: "IX_producto_categoria_id_categoria");

            migrationBuilder.RenameIndex(
                name: "IX_Pagos_ventas_id_venta",
                table: "pagos",
                newName: "IX_pagos_ventas_id_venta");

            migrationBuilder.RenameIndex(
                name: "IX_Compras_usuario_id_usuario",
                table: "compras",
                newName: "IX_compras_usuario_id_usuario");

            migrationBuilder.RenameIndex(
                name: "IX_Carrito_producto_id_producto",
                table: "carrito",
                newName: "IX_carrito_producto_id_producto");

            migrationBuilder.RenameIndex(
                name: "IX_Carrito_clientes_id_cliente",
                table: "carrito",
                newName: "IX_carrito_clientes_id_cliente");

            migrationBuilder.RenameIndex(
                name: "IX_MovimientoInventario_producto_id_producto",
                table: "movimiento_inventario",
                newName: "IX_movimiento_inventario_producto_id_producto");

            migrationBuilder.RenameIndex(
                name: "IX_DetalleVentas_ventas_id_venta",
                table: "detalle_ventas",
                newName: "IX_detalle_ventas_ventas_id_venta");

            migrationBuilder.RenameIndex(
                name: "IX_DetalleVentas_producto_id_producto",
                table: "detalle_ventas",
                newName: "IX_detalle_ventas_producto_id_producto");

            migrationBuilder.RenameIndex(
                name: "IX_DetalleCompra_producto_id_producto",
                table: "detalle_compra",
                newName: "IX_detalle_compra_producto_id_producto");

            migrationBuilder.RenameIndex(
                name: "IX_DetalleCompra_compras_id_compra",
                table: "detalle_compra",
                newName: "IX_detalle_compra_compras_id_compra");

            migrationBuilder.RenameIndex(
                name: "IX_ComprobantesVentas_ventas_id_venta",
                table: "comprobantes_ventas",
                newName: "IX_comprobantes_ventas_ventas_id_venta");

            migrationBuilder.RenameIndex(
                name: "IX_ComprobantesVentas_comprobantes_id_comprobante",
                table: "comprobantes_ventas",
                newName: "IX_comprobantes_ventas_comprobantes_id_comprobante");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ventas",
                table: "ventas",
                column: "id_venta");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuario",
                table: "usuario",
                column: "id_usuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_producto",
                table: "producto",
                column: "id_producto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pagos",
                table: "pagos",
                column: "id_pago");

            migrationBuilder.AddPrimaryKey(
                name: "PK_comprobantes",
                table: "comprobantes",
                column: "id_comprobante");

            migrationBuilder.AddPrimaryKey(
                name: "PK_compras",
                table: "compras",
                column: "id_compra");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clientes",
                table: "clientes",
                column: "id_cliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categoria",
                table: "categoria",
                column: "id_categoria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_carrito",
                table: "carrito",
                column: "id_carrito");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movimiento_inventario",
                table: "movimiento_inventario",
                column: "id_movimiento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_detalle_ventas",
                table: "detalle_ventas",
                column: "id_detalle_venta");

            migrationBuilder.AddPrimaryKey(
                name: "PK_detalle_compra",
                table: "detalle_compra",
                column: "id_detalle_compra");

            migrationBuilder.AddPrimaryKey(
                name: "PK_comprobantes_ventas",
                table: "comprobantes_ventas",
                column: "id_comprobante_venta");

            migrationBuilder.AddForeignKey(
                name: "FK_carrito_clientes_clientes_id_cliente",
                table: "carrito",
                column: "clientes_id_cliente",
                principalTable: "clientes",
                principalColumn: "id_cliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_carrito_producto_producto_id_producto",
                table: "carrito",
                column: "producto_id_producto",
                principalTable: "producto",
                principalColumn: "id_producto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_compras_usuario_usuario_id_usuario",
                table: "compras",
                column: "usuario_id_usuario",
                principalTable: "usuario",
                principalColumn: "id_usuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comprobantes_ventas_comprobantes_comprobantes_id_comprobante",
                table: "comprobantes_ventas",
                column: "comprobantes_id_comprobante",
                principalTable: "comprobantes",
                principalColumn: "id_comprobante",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comprobantes_ventas_ventas_ventas_id_venta",
                table: "comprobantes_ventas",
                column: "ventas_id_venta",
                principalTable: "ventas",
                principalColumn: "id_venta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detalle_compra_compras_compras_id_compra",
                table: "detalle_compra",
                column: "compras_id_compra",
                principalTable: "compras",
                principalColumn: "id_compra",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detalle_compra_producto_producto_id_producto",
                table: "detalle_compra",
                column: "producto_id_producto",
                principalTable: "producto",
                principalColumn: "id_producto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detalle_ventas_producto_producto_id_producto",
                table: "detalle_ventas",
                column: "producto_id_producto",
                principalTable: "producto",
                principalColumn: "id_producto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detalle_ventas_ventas_ventas_id_venta",
                table: "detalle_ventas",
                column: "ventas_id_venta",
                principalTable: "ventas",
                principalColumn: "id_venta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movimiento_inventario_producto_producto_id_producto",
                table: "movimiento_inventario",
                column: "producto_id_producto",
                principalTable: "producto",
                principalColumn: "id_producto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pagos_ventas_ventas_id_venta",
                table: "pagos",
                column: "ventas_id_venta",
                principalTable: "ventas",
                principalColumn: "id_venta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_producto_categoria_categoria_id_categoria",
                table: "producto",
                column: "categoria_id_categoria",
                principalTable: "categoria",
                principalColumn: "id_categoria",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ventas_clientes_clientes_id_cliente",
                table: "ventas",
                column: "clientes_id_cliente",
                principalTable: "clientes",
                principalColumn: "id_cliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ventas_usuario_usuario_id_usuario",
                table: "ventas",
                column: "usuario_id_usuario",
                principalTable: "usuario",
                principalColumn: "id_usuario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carrito_clientes_clientes_id_cliente",
                table: "carrito");

            migrationBuilder.DropForeignKey(
                name: "FK_carrito_producto_producto_id_producto",
                table: "carrito");

            migrationBuilder.DropForeignKey(
                name: "FK_compras_usuario_usuario_id_usuario",
                table: "compras");

            migrationBuilder.DropForeignKey(
                name: "FK_comprobantes_ventas_comprobantes_comprobantes_id_comprobante",
                table: "comprobantes_ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_comprobantes_ventas_ventas_ventas_id_venta",
                table: "comprobantes_ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_detalle_compra_compras_compras_id_compra",
                table: "detalle_compra");

            migrationBuilder.DropForeignKey(
                name: "FK_detalle_compra_producto_producto_id_producto",
                table: "detalle_compra");

            migrationBuilder.DropForeignKey(
                name: "FK_detalle_ventas_producto_producto_id_producto",
                table: "detalle_ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_detalle_ventas_ventas_ventas_id_venta",
                table: "detalle_ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_movimiento_inventario_producto_producto_id_producto",
                table: "movimiento_inventario");

            migrationBuilder.DropForeignKey(
                name: "FK_pagos_ventas_ventas_id_venta",
                table: "pagos");

            migrationBuilder.DropForeignKey(
                name: "FK_producto_categoria_categoria_id_categoria",
                table: "producto");

            migrationBuilder.DropForeignKey(
                name: "FK_ventas_clientes_clientes_id_cliente",
                table: "ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_ventas_usuario_usuario_id_usuario",
                table: "ventas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ventas",
                table: "ventas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuario",
                table: "usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_producto",
                table: "producto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pagos",
                table: "pagos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comprobantes",
                table: "comprobantes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_compras",
                table: "compras");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clientes",
                table: "clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categoria",
                table: "categoria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_carrito",
                table: "carrito");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movimiento_inventario",
                table: "movimiento_inventario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_detalle_ventas",
                table: "detalle_ventas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_detalle_compra",
                table: "detalle_compra");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comprobantes_ventas",
                table: "comprobantes_ventas");

            migrationBuilder.RenameTable(
                name: "ventas",
                newName: "Ventas");

            migrationBuilder.RenameTable(
                name: "usuario",
                newName: "Usuario");

            migrationBuilder.RenameTable(
                name: "producto",
                newName: "Producto");

            migrationBuilder.RenameTable(
                name: "pagos",
                newName: "Pagos");

            migrationBuilder.RenameTable(
                name: "comprobantes",
                newName: "Comprobantes");

            migrationBuilder.RenameTable(
                name: "compras",
                newName: "Compras");

            migrationBuilder.RenameTable(
                name: "clientes",
                newName: "Clientes");

            migrationBuilder.RenameTable(
                name: "categoria",
                newName: "Categoria");

            migrationBuilder.RenameTable(
                name: "carrito",
                newName: "Carrito");

            migrationBuilder.RenameTable(
                name: "movimiento_inventario",
                newName: "MovimientoInventario");

            migrationBuilder.RenameTable(
                name: "detalle_ventas",
                newName: "DetalleVentas");

            migrationBuilder.RenameTable(
                name: "detalle_compra",
                newName: "DetalleCompra");

            migrationBuilder.RenameTable(
                name: "comprobantes_ventas",
                newName: "ComprobantesVentas");

            migrationBuilder.RenameIndex(
                name: "IX_ventas_usuario_id_usuario",
                table: "Ventas",
                newName: "IX_Ventas_usuario_id_usuario");

            migrationBuilder.RenameIndex(
                name: "IX_ventas_clientes_id_cliente",
                table: "Ventas",
                newName: "IX_Ventas_clientes_id_cliente");

            migrationBuilder.RenameIndex(
                name: "IX_producto_categoria_id_categoria",
                table: "Producto",
                newName: "IX_Producto_categoria_id_categoria");

            migrationBuilder.RenameIndex(
                name: "IX_pagos_ventas_id_venta",
                table: "Pagos",
                newName: "IX_Pagos_ventas_id_venta");

            migrationBuilder.RenameIndex(
                name: "IX_compras_usuario_id_usuario",
                table: "Compras",
                newName: "IX_Compras_usuario_id_usuario");

            migrationBuilder.RenameIndex(
                name: "IX_carrito_producto_id_producto",
                table: "Carrito",
                newName: "IX_Carrito_producto_id_producto");

            migrationBuilder.RenameIndex(
                name: "IX_carrito_clientes_id_cliente",
                table: "Carrito",
                newName: "IX_Carrito_clientes_id_cliente");

            migrationBuilder.RenameIndex(
                name: "IX_movimiento_inventario_producto_id_producto",
                table: "MovimientoInventario",
                newName: "IX_MovimientoInventario_producto_id_producto");

            migrationBuilder.RenameIndex(
                name: "IX_detalle_ventas_ventas_id_venta",
                table: "DetalleVentas",
                newName: "IX_DetalleVentas_ventas_id_venta");

            migrationBuilder.RenameIndex(
                name: "IX_detalle_ventas_producto_id_producto",
                table: "DetalleVentas",
                newName: "IX_DetalleVentas_producto_id_producto");

            migrationBuilder.RenameIndex(
                name: "IX_detalle_compra_producto_id_producto",
                table: "DetalleCompra",
                newName: "IX_DetalleCompra_producto_id_producto");

            migrationBuilder.RenameIndex(
                name: "IX_detalle_compra_compras_id_compra",
                table: "DetalleCompra",
                newName: "IX_DetalleCompra_compras_id_compra");

            migrationBuilder.RenameIndex(
                name: "IX_comprobantes_ventas_ventas_id_venta",
                table: "ComprobantesVentas",
                newName: "IX_ComprobantesVentas_ventas_id_venta");

            migrationBuilder.RenameIndex(
                name: "IX_comprobantes_ventas_comprobantes_id_comprobante",
                table: "ComprobantesVentas",
                newName: "IX_ComprobantesVentas_comprobantes_id_comprobante");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ventas",
                table: "Ventas",
                column: "id_venta");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "id_usuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Producto",
                table: "Producto",
                column: "id_producto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pagos",
                table: "Pagos",
                column: "id_pago");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comprobantes",
                table: "Comprobantes",
                column: "id_comprobante");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Compras",
                table: "Compras",
                column: "id_compra");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "id_cliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria",
                column: "id_categoria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carrito",
                table: "Carrito",
                column: "id_carrito");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovimientoInventario",
                table: "MovimientoInventario",
                column: "id_movimiento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetalleVentas",
                table: "DetalleVentas",
                column: "id_detalle_venta");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetalleCompra",
                table: "DetalleCompra",
                column: "id_detalle_compra");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComprobantesVentas",
                table: "ComprobantesVentas",
                column: "id_comprobante_venta");

            migrationBuilder.AddForeignKey(
                name: "FK_Carrito_Clientes_clientes_id_cliente",
                table: "Carrito",
                column: "clientes_id_cliente",
                principalTable: "Clientes",
                principalColumn: "id_cliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carrito_Producto_producto_id_producto",
                table: "Carrito",
                column: "producto_id_producto",
                principalTable: "Producto",
                principalColumn: "id_producto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Usuario_usuario_id_usuario",
                table: "Compras",
                column: "usuario_id_usuario",
                principalTable: "Usuario",
                principalColumn: "id_usuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComprobantesVentas_Comprobantes_comprobantes_id_comprobante",
                table: "ComprobantesVentas",
                column: "comprobantes_id_comprobante",
                principalTable: "Comprobantes",
                principalColumn: "id_comprobante",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComprobantesVentas_Ventas_ventas_id_venta",
                table: "ComprobantesVentas",
                column: "ventas_id_venta",
                principalTable: "Ventas",
                principalColumn: "id_venta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCompra_Compras_compras_id_compra",
                table: "DetalleCompra",
                column: "compras_id_compra",
                principalTable: "Compras",
                principalColumn: "id_compra",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCompra_Producto_producto_id_producto",
                table: "DetalleCompra",
                column: "producto_id_producto",
                principalTable: "Producto",
                principalColumn: "id_producto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleVentas_Producto_producto_id_producto",
                table: "DetalleVentas",
                column: "producto_id_producto",
                principalTable: "Producto",
                principalColumn: "id_producto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleVentas_Ventas_ventas_id_venta",
                table: "DetalleVentas",
                column: "ventas_id_venta",
                principalTable: "Ventas",
                principalColumn: "id_venta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientoInventario_Producto_producto_id_producto",
                table: "MovimientoInventario",
                column: "producto_id_producto",
                principalTable: "Producto",
                principalColumn: "id_producto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_Ventas_ventas_id_venta",
                table: "Pagos",
                column: "ventas_id_venta",
                principalTable: "Ventas",
                principalColumn: "id_venta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Categoria_categoria_id_categoria",
                table: "Producto",
                column: "categoria_id_categoria",
                principalTable: "Categoria",
                principalColumn: "id_categoria",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Clientes_clientes_id_cliente",
                table: "Ventas",
                column: "clientes_id_cliente",
                principalTable: "Clientes",
                principalColumn: "id_cliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Usuario_usuario_id_usuario",
                table: "Ventas",
                column: "usuario_id_usuario",
                principalTable: "Usuario",
                principalColumn: "id_usuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
