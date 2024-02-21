using FoodyTekmerDataAccessLayer.Context;
using FoodyTekmerEntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace FoodyTekmerWebUI.Controllers
{
    public class CategoryController : Controller
    {
        FoodyContext context = new FoodyContext();

        public IActionResult Index(int page = 1)
        {
            var values = context.Categories.ToList().ToPagedList(page, 5);
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Category c)
        {
            context.Categories.Add(c);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteCategory(int id)
        {
            var value = context.Categories.Find(id);
            context.Categories.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var value = context.Categories.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category c)
        {
            context.Categories.Update(c);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
