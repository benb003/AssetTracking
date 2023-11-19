using AssetTracking.Models;
using AssetTracking.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssetTracking.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Office> offices = _context.Offices.Include(p => p.Products);
            return View(offices);
        }

        public IActionResult ShowDeadProducts()
        {
            IEnumerable<Product> products = _context.Products;
            List<Product> deads = new List<Product>();
            foreach (var product in products)
            {
                TimeSpan timeSpan = DateTime.Today - product.PurchaseDate;
                if (timeSpan.TotalDays > 1095)
                {
                    deads.Add(product);
                }
            }
            IEnumerable<Product> deadProduct = deads.ToList();
            return View(deadProduct);
        }

        public IActionResult DeadProductsInThree()
        {
            IEnumerable<Product> products = _context.Products;
            List<Product> deads = new List<Product>();
            foreach (var product in products)
            {
                TimeSpan timeSpan = DateTime.Today - product.PurchaseDate;
                if (timeSpan.TotalDays <= 1095 && timeSpan.TotalDays > 1005)
                {
                    deads.Add(product);
                }
            }
            IEnumerable<Product> deadProduct = deads.ToList();
            return View(deadProduct);
        }

        public IActionResult DeadProductsInSix()
        {
            IEnumerable<Product> products = _context.Products;
            List<Product> deads = new List<Product>();
            foreach (var product in products)
            {
                TimeSpan timeSpan = DateTime.Today - product.PurchaseDate;
                if (timeSpan.TotalDays <= 1005 && timeSpan.TotalDays > 915)
                {
                    deads.Add(product);
                }
            }
            IEnumerable<Product> deadProduct = deads.ToList();
            return View(deadProduct);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return Redirect("Index");
            }

            return View(product);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Product product)
        {
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
