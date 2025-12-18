using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppPractiece.Data;
using WebAppPractiece.Models;
using WebAppPractiece.ViewModels;

namespace WebAppPractiece.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //HttpContext.Session.SetString("name","Mahmud");
            //HttpContext.Response.Cookies.Append("surname","Rahimli",new CookieOptions() 
            //{ 
            //    MaxAge = TimeSpan.FromSeconds(10)
            //});
            //ViewBag.Name = HttpContext.Session.GetString("name");
            //ViewBag.Surname = HttpContext.Request.Cookies["surname"];

            var sliders = await _context.Sliders.Where(m => !m.IsDeleted).ToListAsync();
            var sliderDetail = await _context.SlidersDetails.FirstOrDefaultAsync(m => !m.IsDeleted);
            var categories = await _context.Categories.Where(m => !m.IsDeleted).ToListAsync();

            var products = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.Category)
                .Where(m => !m.IsDeleted)
                .Take(4)
                .ToListAsync();

            HomeVM homeVM = new()
            {
                Sliders = sliders,
                SliderDetail = sliderDetail,
                Products = products,
                Categories = categories
            };

            ViewBag.ProductCount = await _context.Products.CountAsync(m => !m.IsDeleted);

            return View(homeVM);
        }

        public async Task<IActionResult> LoadMore(int skip)
        {
            var products = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.Category)
                .Where(m => !m.IsDeleted)
                .Skip(skip)
                .Take(4)
                .ToListAsync();

            return PartialView("_ProductPartial", products);
        }
    }
}