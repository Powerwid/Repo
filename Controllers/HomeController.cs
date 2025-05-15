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

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Si no hay sesión activa para cliente o usuario, redirigir a Login
            if (HttpContext.Session.GetInt32("ClienteId") == null && HttpContext.Session.GetInt32("UsuarioId") == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        // ----- CLIENTE LOGIN -----
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteExistente = _context.Clientes
                    .FirstOrDefault(c => c.correo == cliente.correo && c.telefono == cliente.telefono);

                if (clienteExistente != null)
                {
                    HttpContext.Session.SetInt32("ClienteId", clienteExistente.id_cliente);
                    HttpContext.Session.SetString("UsuarioRol", "Cliente"); // Guardar rol
                    return RedirectToAction("Index", "Home");
                }

                ViewData["Error"] = "Correo o teléfono incorrectos.";
            }

            return View(cliente);
        }

        // ----- ADMIN LOGIN -----
        public IActionResult LoginAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginAdmin(Usuarios usuarioModel)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Usuarios
                    .FirstOrDefault(u => u.usuario == usuarioModel.usuario && u.contraseña == usuarioModel.contraseña);

                if (user != null)
                {
                    HttpContext.Session.SetInt32("UsuarioId", user.id_usuario);
                    HttpContext.Session.SetString("UsuarioRol", user.rol ?? "Administrador"); // Guardar rol
                    return RedirectToAction("Index", "Home");
                }

                ViewData["Error"] = "Usuario o contraseña incorrectos.";
            }

            return View(usuarioModel);
        }

        // Registro de cliente
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();

                if (cliente.id_cliente > 0)
                {
                    HttpContext.Session.SetInt32("ClienteId", cliente.id_cliente);
                    HttpContext.Session.SetString("UsuarioRol", "Cliente");
                    return RedirectToAction("Index", "Home");
                }

                ViewData["Error"] = "Hubo un problema al crear la cuenta.";
            }

            return View(cliente);
        }

        // Cerrar sesión (limpiar sesión)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            // Limpiar todas las claves de la sesión
            HttpContext.Session.Clear();
            TempData["Success"] = "Sesión cerrada con éxito.";
            return RedirectToAction("Login", "Home"); // Redirigir directamente a Login
        }

        public IActionResult NoAutorizado()
        {
            return View();
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