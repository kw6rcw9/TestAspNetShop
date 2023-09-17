using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using testAspShop.Data;
using testAspShop.Models;

namespace testAspShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;


        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            List<Item> items = _context.items.ToList();
           

            return View(items);
        }
        public IActionResult Product(int id)
        {
            Item items = _context.items.Find(id) ?? new Item();


            return View(items);
        }
        public IActionResult Cups()
        {
            List<Item> items = _context.items.Where(el => el.CategoryID == 1).ToList();


            return View(items);
        }
        public IActionResult Tshirts()
        {
            List<Item> items = _context.items.Where(el => el.CategoryID == 2).ToList();


            return View(items);
        }
        public IActionResult About()
        {
            return View();
        }

      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}