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
       
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Blog post)
        {
            if (ModelState.IsValid)
            {
                _context.posts.Add(post);
                _context.SaveChanges();
                return Redirect("/blog");
            }
            return View();
        }

        [Route("blog/{id:int}/edit")]
        public ActionResult Edit(int id)
        {

            return View();

        }

        [HttpPost]
        [Route("blog/{id:int}/edit")]
        public IActionResult Edit(Blog editPost, int id)
        {
            if (ModelState.IsValid)
            {
                Blog? post = _context.posts.Find(id);
                post.Title = editPost.Title;
                post.Annons = editPost.Annons;
                post.FullText = editPost.FullText;
                _context.posts.Update(post);
                _context.SaveChanges();
                return Redirect("/blog");
            }
            return View();

        }
        
        [Route("blog/{id:int}/delete")]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Blog? post = _context.posts.Find(id) ?? new Blog();
                _context.posts.Remove(post);
                _context.SaveChanges();
            }
                return Redirect("/blog");
           



        }
    }
}
