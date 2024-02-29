using FoodyTekmerDataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace FoodyTekmerWebUI.Controllers
{
    public class AdminHomeController : Controller
    {
        FoodyContext context = new();

        public IActionResult Index()
        {
            ViewBag.product = context.Products.Count();
            ViewBag.category = context.Categories.Count();
            ViewBag.testimonial = context.Testimonials.Count();
            ViewBag.contact = context.Contacts.Count();
            ViewBag.newMail = context.Contacts.Where(x => x.Status == false).Count();

            return View();
        }
    }
}
