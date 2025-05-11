using System;
   using Microsoft.AspNetCore.Mvc;
   using SistemaVentas.Data;
   using SistemaVentas.Models.Entities;
   using Microsoft.EntityFrameworkCore;
   using Microsoft.AspNetCore.Http;
   using System.Collections.Generic;
   using System.Linq;

   namespace SistemaVentas.Controllers
   {
       public class CarritoController : Controller
       {
           private readonly AppDbContext _context;

           public CarritoController(AppDbContext context)
           {
               _context = context;
           }

           // Mostrar el carrito
           public IActionResult Index()
           {
               // Verificar si el usuario está logueado
               if (HttpContext.Session.GetInt32("ClienteId") == null)
               {
                   return RedirectToAction("Login", "Home");
               }

               // Recuperar el carrito de la sesión
               var carrito = HttpContext.Session.GetString("Cart");
               List<(Producto Producto, int Cantidad)> itemsCarrito = new List<(Producto, int Cantidad)>();

               if (!string.IsNullOrEmpty(carrito))
               {
                   var listaCarrito = carrito.Split(',').Select(x =>
                   {
                       var partes = x.Split(':');
                       return new { ProductId = int.Parse(partes[0]), Cantidad = int.Parse(partes[1]) };
                   }).ToList();

                   foreach (var item in listaCarrito)
                   {
                       var producto = _context.Producto.Find(item.ProductId);
                       if (producto != null)
                       {
                           itemsCarrito.Add((producto, item.Cantidad));
                       }
                   }
               }

               ViewBag.Total = itemsCarrito.Sum(item => item.Producto.precio * item.Cantidad);
               return View(itemsCarrito);
           }

           // Agregar un producto al carrito
           [HttpPost]
           public IActionResult Agregar(int id, int cantidad = 1)
           {
               if (HttpContext.Session.GetInt32("ClienteId") == null)
               {
                   return RedirectToAction("Login", "Home");
               }

               var producto = _context.Producto.Find(id);
               if (producto == null || producto.stock < cantidad)
               {
                   TempData["Error"] = "Producto no disponible o stock insuficiente.";
                   return RedirectToAction("Index", "Producto");
               }

               var carrito = HttpContext.Session.GetString("Cart") ?? "";
               var itemsCarrito = string.IsNullOrEmpty(carrito)
                   ? new List<(int ProductId, int Cantidad)>()
                   : carrito.Split(',').Select(x =>
                   {
                       var partes = x.Split(':');
                       return (ProductId: int.Parse(partes[0]), Cantidad: int.Parse(partes[1]));
                   }).ToList();

               var itemExistente = itemsCarrito.FirstOrDefault(x => x.ProductId == id);
               if (itemExistente.ProductId == id)
               {
                   itemsCarrito.Remove(itemExistente);
                   itemsCarrito.Add((id, itemExistente.Cantidad + cantidad));
               }
               else
               {
                   itemsCarrito.Add((id, cantidad));
               }

               HttpContext.Session.SetString("Cart", string.Join(",", itemsCarrito.Select(x => $"{x.ProductId}:{x.Cantidad}")));
               TempData["Success"] = "Producto añadido al carrito.";
               return RedirectToAction("Index", "Producto");
           }

           // Eliminar un producto del carrito
           [HttpPost]
           public IActionResult Eliminar(int productId)
           {
               var carrito = HttpContext.Session.GetString("Cart");
               if (!string.IsNullOrEmpty(carrito))
               {
                   var itemsCarrito = carrito.Split(',').Select(x =>
                   {
                       var partes = x.Split(':');
                       return (ProductId: int.Parse(partes[0]), Cantidad: int.Parse(partes[1]));
                   }).ToList();

                   var itemAEliminar = itemsCarrito.FirstOrDefault(x => x.ProductId == productId);
                   if (itemAEliminar.ProductId == productId)
                   {
                       itemsCarrito.Remove(itemAEliminar);
                       HttpContext.Session.SetString("Cart", string.Join(",", itemsCarrito.Select(x => $"{x.ProductId}:{x.Cantidad}")));
                   }
               }

               return RedirectToAction("Index");
           }

           // Confirmar la compra
           [HttpPost]
           public IActionResult ConfirmarCompra(string metodoPago)
           {
               if (HttpContext.Session.GetInt32("ClienteId") == null)
               {
                   return RedirectToAction("Login", "Home");
               }

               var clienteId = HttpContext.Session.GetInt32("ClienteId").Value;
               var carrito = HttpContext.Session.GetString("Cart");

               if (string.IsNullOrEmpty(carrito))
               {
                   TempData["Error"] = "El carrito está vacío.";
                   return RedirectToAction("Index");
               }

               var itemsCarrito = carrito.Split(',').Select(x =>
               {
                   var partes = x.Split(':');
                   return (ProductId: int.Parse(partes[0]), Cantidad: int.Parse(partes[1]));
               }).ToList();

               // Usar el ID del usuario "Kleyn" (id_usuario = 1)
               int usuarioId = 1; // Ajusta si el id_usuario generado es diferente

               // Opcional: Verificar si el usuario existe
               var usuario = _context.Usuario.Find(usuarioId);
               if (usuario == null)
               {
                   TempData["Error"] = "No se encontró un usuario válido para procesar la venta.";
                   return RedirectToAction("Index");
               }

               // Crear un registro en Ventas
               var venta = new Ventas
               {
                   usuario_id_usuario = usuarioId, // Usa el ID del usuario "Kleyn"
                   clientes_id_cliente = clienteId
               };

               decimal total = 0;
               var detallesVentas = new List<DetalleVentas>();

               foreach (var item in itemsCarrito)
               {
                   var producto = _context.Producto.Find(item.ProductId);
                   if (producto == null || producto.stock < item.Cantidad)
                   {
                       TempData["Error"] = "Uno o más productos no están disponibles.";
                       return RedirectToAction("Index");
                   }

                   var subtotal = producto.precio * item.Cantidad;
                   total += subtotal;

                   // Agregar a DetalleVentas
                   detallesVentas.Add(new DetalleVentas
                   {
                       ventas_id_venta = 0, // Se actualizará después
                       producto_id_producto = item.ProductId,
                       cantidad = item.Cantidad,
                       precio_unitario = producto.precio,
                       subtotal = subtotal
                   });

                   // Actualizar el stock del producto
                   producto.stock -= item.Cantidad;
                   _context.Producto.Update(producto);

                   // Registrar el movimiento de inventario
                   var movimiento = new MovimientoInventario
                   {
                       producto_id_producto = item.ProductId,
                       tipo_movimiento = "Salida",
                       cantidad = item.Cantidad,
                       fecha_movimiento = DateTime.Now,
                       motivo = "Venta"
                   };
                   _context.MovimientoInventario.Add(movimiento);
               }

               // Guardar la venta para obtener el id_venta
               _context.Ventas.Add(venta);
               _context.SaveChanges();

               // Asignar detallesVentas a la venta
               foreach (var detalle in detallesVentas)
               {
                   detalle.ventas_id_venta = venta.id_venta;
                   _context.DetalleVentas.Add(detalle);
               }

               // Crear el pago asociado a la venta
               var pago = new Pagos
               {
                   ventas_id_venta = venta.id_venta, // Usa el id_venta generado
                   metodo_pago = metodoPago,
                   monto_pagado = total,
                   fecha_pago = DateTime.Now
               };
               _context.Pagos.Add(pago);

               _context.SaveChanges();

               // Limpiar el carrito
               HttpContext.Session.Remove("Cart");

               TempData["Success"] = "Compra realizada con éxito.";
               return RedirectToAction("Historial", "Clientes");
           }
       }
   }