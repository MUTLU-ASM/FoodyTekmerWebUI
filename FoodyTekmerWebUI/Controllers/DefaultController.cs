﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodyTekmerWebUI.Controllers
{
    public class DefaultController : Controller
    {
		[AllowAnonymous]
		public IActionResult Index()
        {
            ViewBag.title1 = "Ürünler";
            ViewBag.title2 = "Ana Sayfa";
            ViewBag.title3 = "Ürün Listesi";
            return View();
        }
        public PartialViewResult PartialHeader()
        {
            return PartialView();
        }
    }
}
