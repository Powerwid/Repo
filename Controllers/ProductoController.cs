using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVentas.Data;
using SistemaVentas.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace SistemaVentas.Controllers
{
    public class ProductoController : Controller
    {
        private readonly AppDbContext _context;

        public ProductoController(AppDbContext context)
        {
            _context = context;
        }

        // Método auxiliar para validar si el usuario es Administrador
        private bool IsAdmin()
        {
            var rol = HttpContext.Session.GetString("UsuarioRol");
            return rol == "Administrador";
        }

        // GET: Producto
        public IActionResult Index()
        {
            // Obtener el rol desde sesión y pasarlo a la vista
            var rol = HttpContext.Session.GetString("UsuarioRol") ?? "Cliente";
            ViewBag.UsuarioRol = rol;

            var productos = _context.Producto.ToList();
            return View(productos);
        }

        // GET: Producto/Create
        public IActionResult Create()
        {
            if (!IsAdmin())
                return RedirectToAction("Index");

            ViewBag.Categorias = new SelectList(_context.Categoria, "id_categoria", "nombre");
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Producto producto)
        {
            if (!IsAdmin())
                return RedirectToAction("Index");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(producto);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error al guardar el producto: " + ex.Message);
                }
            }
            ViewBag.Categorias = new SelectList(_context.Categoria, "id_categoria", "nombre");
            return View(producto);
        }

        // GET: Producto/Edit/5
        public IActionResult Edit(int? id)
        {
            if (!IsAdmin())
                return RedirectToAction("Index");

            if (id == null)
                return NotFound();

            var producto = _context.Producto.Find(id);
            if (producto == null)
                return NotFound();

            ViewBag.Categorias = new SelectList(_context.Categoria, "id_categoria", "nombre");
            return View(producto);
        }

        // POST: Producto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Producto producto)
        {
            if (!IsAdmin())
                return RedirectToAction("Index");

            if (id != producto.id_producto)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error al actualizar el producto: " + ex.Message);
                }
            }
            ViewBag.Categorias = new SelectList(_context.Categoria, "id_categoria", "nombre");
            return View(producto);
        }

        // GET: Producto/Delete/5
        public IActionResult Delete(int? id)
        {
            if (!IsAdmin())
                return RedirectToAction("Index");

            if (id == null)
                return NotFound();

            var producto = _context.Producto.Find(id);
            if (producto == null)
                return NotFound();

            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (!IsAdmin())
                return RedirectToAction("Index");

            var producto = _context.Producto.Find(id);
            if (producto != null)
            {
                _context.Producto.Remove(producto);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
