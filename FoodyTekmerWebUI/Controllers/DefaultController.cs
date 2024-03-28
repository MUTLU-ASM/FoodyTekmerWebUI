using FoodyTekmerBusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FoodyTekmerWebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IProductService _productService;

        public DefaultController(IProductService productService)
        {
            _productService = productService;
        }

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

        public IActionResult ProductList()
        {
            var jsonProduct = JsonConvert.SerializeObject(_productService.TGetAllList().Take(8));
            return Json(jsonProduct);
        }
        public IActionResult ProductVegetableList()
        {
            var jsonVegetable = JsonConvert.SerializeObject(_productService.TGetListProductWithAjax(1).Take(8));
            return Json(jsonVegetable);
        }
        public IActionResult ProductFruitList()
        {
            var jsonFruit = JsonConvert.SerializeObject(_productService.TGetListProductWithAjax(2).Take(8));
            return Json(jsonFruit);
        }
        public IActionResult ProductMilkList()
        {
            var jsonMilk = JsonConvert.SerializeObject(_productService.TGetListProductWithAjax(5).Take(8));
            return Json(jsonMilk);
        }
    }
}
