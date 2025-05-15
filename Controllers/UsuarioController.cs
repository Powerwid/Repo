using Microsoft.AspNetCore.Mvc;
using SistemaVentas.Data;
using SistemaVentas.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace SistemaVentas.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult CreateAdmin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Usuarios admin)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Guardar usuario en la base de datos
                    _context.Usuarios.Add(admin);
                    _context.SaveChanges();

                    // Guardar el ID del ususario en la sesión
                    HttpContext.Session.SetInt32("UsuarioId", admin.id_usuario);

                    // Redirigir a la página de inicio
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    // Mostrar error si ocurre un problema al guardar
                    ViewData["Error"] = $"Error al registrar el usuario: {ex.Message}";
                }
            }

            // Si la validación falla, regresa al formulario
            return View(admin);
        }

    }
}