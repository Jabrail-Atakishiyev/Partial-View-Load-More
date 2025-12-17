using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppPractiece.Data;
using WebAppPractiece.Models;

namespace WebAppPractiece.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderDetailsController : Controller
    {
        private readonly AppDbContext _context;

        public SliderDetailsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<SliderDetail> sliders = await _context.SlidersDetails.Where(m => !m.IsDeleted).ToListAsync();
            return View(sliders);
        }
    }
}
