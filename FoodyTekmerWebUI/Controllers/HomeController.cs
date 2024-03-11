using FoodyTekmerBusinessLayer.Abstract;
using FoodyTekmerDataAccessLayer.Context;
using FoodyTekmerEntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodyTekmerWebUI.Controllers
{
    [AllowAnonymous]
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
    }
}
