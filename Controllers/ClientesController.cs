using Microsoft.AspNetCore.Mvc;
using SistemaVentas.Data;
using SistemaVentas.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace SistemaVentas.Controllers
{
    public class ClientesController : Controller
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Establecer valores por defecto
                    cliente.fecha_venta = DateTime.Now;
                    cliente.estado = "Activo"; // Estado por defecto
                    cliente.monto_total = 0; // Inicializamos en 0, se actualizará con las compras

                    // Guardar cliente en la base de datos
                    _context.Clientes.Add(cliente);
                    _context.SaveChanges();

                    // Guardar el ID del cliente en la sesión
                    HttpContext.Session.SetInt32("ClienteId", cliente.id_cliente);

                    // Redirigir a la página de inicio
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    // Mostrar error si ocurre un problema al guardar
                    ViewData["Error"] = $"Error al registrar el cliente: {ex.Message}";
                }
            }

            // Si la validación falla, regresa al formulario
            return View(cliente);
        }

        // GET: Clientes/Historial
        public IActionResult Historial()
        {
            // Verificar si el usuario está logueado
            if (HttpContext.Session.GetInt32("ClienteId") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            // Obtener el ID del cliente desde la sesión
            var clienteId = HttpContext.Session.GetInt32("ClienteId").Value;

            // Recuperar las compras del cliente, incluyendo los detalles y los productos
            var compras = _context.Compras
                .Include(c => c.DetalleCompra)
                .ThenInclude(d => d.producto)
                .Where(c => c.cliente_id_cliente == clienteId)
                .ToList();

            // Pasar las compras a la vista
            return View(compras);
        }
    }
}