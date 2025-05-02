using Microsoft.AspNetCore.Mvc;
using SistemaVentas.Data;
using SistemaVentas.Models.Entities;

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
                // Establecer otros valores como la fecha de venta y estado por defecto
                cliente.fecha_venta = DateTime.Now;
                cliente.estado = "Activo"; // Puedes cambiarlo si es necesario

                // Guardar cliente en la base de datos
                _context.Clientes.Add(cliente);
                _context.SaveChanges();

                // Guardar el ID del cliente en la sesión para que se use en otras operaciones
                HttpContext.Session.SetInt32("ClienteId", cliente.id_cliente);

                // Redirigir a la página de inicio o a la página que prefieras
                return RedirectToAction("Index", "Home");
            }

            // Si la validación falla, regresa al formulario
            return View(cliente);
        }
    }
}

