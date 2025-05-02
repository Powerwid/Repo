using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVentas.Data;
using SistemaVentas.Models.Entities;

namespace SistemaVentas.Controllers
{
    public class CarritoController : Controller
    {
        private readonly AppDbContext _context;

        public CarritoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Carrito
        public IActionResult Index()
        {
            // Obtener los elementos del carrito del cliente con ID 1 (cliente de prueba)
            var carritos = _context.Carrito
                .Include(c => c.producto)
                .Include(c => c.cliente)
                .Where(c => c.clientes_id_cliente == 1)
                .ToList();

            return View(carritos);
        }

        // POST: Carrito/Agregar
        [HttpPost]
        public IActionResult Agregar(int id)
        {
            // Buscar el producto
            var producto = _context.Producto.FirstOrDefault(p => p.id_producto == id);
            if (producto == null)
            {
                return NotFound("Producto no encontrado.");
            }

            // Cliente fijo de prueba
            int clienteId = 1;

            // Buscar  cliente
            var cliente = _context.Clientes.FirstOrDefault(c => c.id_cliente == clienteId);
            if (cliente == null)
            {
                return NotFound("Cliente no encontrado.");
            }

            // Verificar si ya existe en el carrito
            var itemExistente = _context.Carrito.FirstOrDefault(c =>
                c.producto_id_producto == id && c.clientes_id_cliente == clienteId);

            if (itemExistente != null)
            {
                itemExistente.cantidad += 1;
                itemExistente.fecha_agregado = DateTime.Now;
                _context.Carrito.Update(itemExistente);
            }
            else
            {
                var nuevoItem = new Carrito
                {
                    producto_id_producto = producto.id_producto,
                    producto = producto,
                    clientes_id_cliente = clienteId,
                    cliente = cliente,
                    cantidad = 1,
                    fecha_agregado = DateTime.Now,
                    estado = "Activo"
                };

                _context.Carrito.Add(nuevoItem);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Producto");
        }
    }
}
