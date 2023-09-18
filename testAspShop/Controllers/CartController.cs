using Microsoft.AspNetCore.Mvc;
using testAspShop.Data;
using testAspShop.Models;
namespace testAspShop.Controllers
{
    public class CartController : Controller
    {
        
        private readonly AppDbContext _context;


        public CartController( AppDbContext context)
        {
            _context = context;
           
        }

        public IActionResult Index()
        {
            List<Item> items = new List<Item>();
            
            String sessionItems = HttpContext.Session.GetString("items_id") ?? "";
            if(string.IsNullOrEmpty(sessionItems))
            {
                ViewBag.NoItems = "Нет товаров в корзине";
                return View(items);
            }

            int[] itemsId = Array.ConvertAll( sessionItems.Split(','), int.Parse);

            items = _context.items.Where(x => itemsId.Contains(x.Id)).ToList();

            
                ViewBag.Summary = items.Sum(x => x.Price);

            
           
            return View(items);
        }

        public RedirectResult AddToCart(int id)
        {
            String idStr = id.ToString();
            String sessionItems = HttpContext.Session.GetString("items_id") ?? "";

            if (!sessionItems.Contains(idStr))
            {


                if (!sessionItems.Equals("")) sessionItems += "," + idStr;
                else sessionItems = idStr;
                HttpContext.Session.SetString("items_id", sessionItems);
            }
            return Redirect("/cart");
        }

        [HttpGet]
        public ActionResult Order()
        {
            ViewBag.sessionItems = HttpContext.Session.GetString("items_id") ?? "";
            return View();
        }

        [HttpPost]
        public IActionResult Order(Order order)
        {
            if (ModelState.IsValid)
            {
                _context.orders.Add(order); 
                _context.SaveChanges();
                return Redirect("/");
            }
            ViewBag.sessionItems = HttpContext.Session.GetString("items_id") ?? "";
            return View();

        }
    }
}
