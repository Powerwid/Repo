using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SistemaVentas.Data;
using SistemaVentas.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace SistemaVentas.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Categoria
        public IActionResult Index()
        {
            var categorias = _context.Categoria.ToList();
            return View(categorias);
        }

        // GET: Categoria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(categoria);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error al guardar la categoría: " + ex.Message);
                }
            }
            return View(categoria);
        }

        // GET: Categoria/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = _context.Categoria.Find(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Categoria categoria)
        {
            if (id != categoria.id_categoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoria);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error al actualizar la categoría: " + ex.Message);
                }
            }
            return View(categoria);
        }

        // GET: Categoria/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = _context.Categoria.Find(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var categoria = _context.Categoria.Find(id);
            if (categoria != null)
            {
                _context.Categoria.Remove(categoria);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}