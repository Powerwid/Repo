using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVentas.Data;
using SistemaVentas.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SistemaVentas.Controllers
{
    public class ProductoController : Controller
    {
        private readonly AppDbContext _context;

        public ProductoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Producto
        public IActionResult Index()
        {
            var productos = _context.Producto.ToList();
            return View(productos);
        }

        // GET: Producto/Create
        public IActionResult Create()
        {
            // Cargar las categorías disponibles para el desplegable
            ViewBag.Categorias = new SelectList(_context.Categoria, "id_categoria", "nombre");
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Producto producto)
        {
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
                    // Mostrar el error al usuario
                    ModelState.AddModelError(string.Empty, "Error al guardar el producto: " + ex.Message);
                }
            }
            // Volver a cargar las categorías en caso de error
            ViewBag.Categorias = new SelectList(_context.Categoria, "id_categoria", "nombre");
            return View(producto);
        }

        // GET: Producto/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = _context.Producto.Find(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewBag.Categorias = new SelectList(_context.Categoria, "id_categoria", "nombre");
            return View(producto);
        }

        // POST: Producto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Producto producto)
        {
            if (id != producto.id_producto)
            {
                return NotFound();
            }

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
            if (id == null)
            {
                return NotFound();
            }

            var producto = _context.Producto.Find(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
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