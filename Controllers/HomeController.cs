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
                    HttpContext.Session.SetString("UsuarioRol", "Cliente");

                    return RedirectToAction("Index", "Home");
                }

                ViewData["Error"] = "Correo o teléfono incorrectos.";
            }

            return View(cliente);
        }

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
                    HttpContext.Session.SetString("UsuarioRol", user.rol ?? "Administrador");

                    return RedirectToAction("Index", "Home");
                }

                ViewData["Error"] = "Usuario o contraseña incorrectos.";
            }

            return View(usuarioModel);
        }

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

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
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
