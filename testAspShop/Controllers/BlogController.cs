using Microsoft.AspNetCore.Mvc;
using testAspShop.Data;
using testAspShop.Models;
using System.Collections;


namespace testAspShop.Controllers
{
    public class BlogController : Controller
    {

        private readonly AppDbContext _context;

        public BlogController(AppDbContext context) => _context = context;
        public IActionResult Index() // blog/
        {
            List<Blog> posts = _context.posts.ToList();
            return View(posts);
        }
    }
}
