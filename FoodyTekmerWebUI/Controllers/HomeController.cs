using FoodyTekmerDataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace FoodyTekmerWebUI.Controllers
{
    public class HomeController : Controller
    {
        FoodyContext context=new FoodyContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            var values = context.Abouts.ToList();
            return View(values);
        }
        public IActionResult Contact()
        {    
            return View();
        }
    }
}
