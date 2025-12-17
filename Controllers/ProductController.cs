using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppPractiece.Data;
using WebAppPractiece.Models;

namespace WebAppPractiece.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await _context.Products.Include(p => p.ProductImages)
                .Include(p => p.Category).Take(4).Where(m => !m.IsDeleted)
                .ToListAsync();
            return View(products);
        }
    }
}
