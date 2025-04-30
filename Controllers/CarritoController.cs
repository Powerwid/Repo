using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVentas.Data;
using SistemaVentas.Models.Entities;
using System.Linq;

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
            var carritos = _context.carrito
                .Include(c => c.cliente)
                .Include(c => c.producto)
                .ToList();
            return View(carritos);
        }
    }
}