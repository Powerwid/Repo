using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVentas.Data;
using SistemaVentas.Models.Entities;
using System.Linq;

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
            var productos = _context.producto.ToList();
            return View(productos);
        }

        // GET: Producto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Producto/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = _context.producto.Find(id);
            if (producto == null)
            {
                return NotFound();
            }
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
                _context.Update(producto);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Producto/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = _context.producto.Find(id);
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
            var producto = _context.producto.Find(id);
            _context.producto.Remove(producto);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}