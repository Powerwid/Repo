using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SistemaVentas.Data;
using SistemaVentas.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace SistemaVentas.Controllers
{
    public class CarritoController : Controller
    {
        private readonly AppDbContext _context;

        public CarritoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Carrito
        public IActionResult Index()
        {
            var carritos = _context.Carrito.ToList();
            return View(carritos);
        }
    }
}