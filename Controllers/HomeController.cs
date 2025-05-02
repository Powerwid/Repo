using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SistemaVentas.Models;
using SistemaVentas.Data;
using SistemaVentas.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace SistemaVentas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        // Constructor con inyección de dependencias
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Acción para mostrar la página de inicio
        public IActionResult Index()
        {
            // Verificar si hay un cliente en la sesión
            if (HttpContext.Session.GetInt32("ClienteId") == null)
            {
                // Si no hay cliente, redirigir a la acción Login
                return RedirectToAction("Login");
            }

            // Si ya hay cliente en sesión, mostrar la vista de inicio
            return View();
        }

        // Acción para mostrar el formulario de login
        public IActionResult Login()
        {
            return View();
        }

        // Acción para procesar el login
        [HttpPost]
        public IActionResult Login(Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                // Buscar el cliente en la base de datos por correo y teléfono
                var clienteExistente = _context.Clientes
                                               .FirstOrDefault(c => c.correo == cliente.correo && c.telefono == cliente.telefono);

                if (clienteExistente != null)
                {
                    // Si el cliente existe, guardar su ID en la sesión
                    HttpContext.Session.SetInt32("ClienteId", clienteExistente.id_cliente);

                    // Redirigir al inicio después de iniciar sesión
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Si no existe el cliente, mostrar un error
                    ViewData["Error"] = "Correo o teléfono incorrectos.";
                }
            }

            // Si el modelo no es válido o el inicio de sesión falló, devolver al formulario de login
            return View(cliente);
        }

        // Acción para mostrar el formulario de registro de cliente
        public IActionResult Crear()
        {
            return View();
        }

        // Acción para procesar la creación del cliente
        [HttpPost]
        public IActionResult Crear(Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                // Agregar el nuevo cliente a la base de datos
                _context.Clientes.Add(cliente);
                _context.SaveChanges();

                // Guardar el ID del cliente recién creado en la sesión
                HttpContext.Session.SetInt32("ClienteId", cliente.id_cliente);

                // Redirigir a la página principal después de la creación del cliente
                return RedirectToAction("Index", "Home");
            }

            // Si el modelo no es válido, volver al formulario de registro
            return View(cliente);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
