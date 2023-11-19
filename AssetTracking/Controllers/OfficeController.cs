using AssetTracking.Models;
using AssetTracking.Services;
using Microsoft.AspNetCore.Mvc;

namespace AssetTracking.Controllers
{
    public class OfficeController : Controller
    {
        private readonly AppDbContext _context;

        public OfficeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Office> offices = _context.Offices;
            return View(offices);
        }
    }
}
