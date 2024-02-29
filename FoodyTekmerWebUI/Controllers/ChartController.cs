using FoodyTekmerBusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FoodyTekmerWebUI.Controllers
{
    public class ChartController : Controller
    {
        private readonly IProductService _productService;

        public ChartController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var values = _productService.TGetAllList().ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult ProductChart()
        {
            var products = _productService.TGetAllList()
                                           .Select(x => new { x.Name, x.Stock })
                                            .ToList();
            return Json(products);
        }
        [HttpGet]
        public IActionResult ProductPriceChart()
        {
            var products = _productService.TGetAllList()
                                           .Select(x => new { x.Name, x.NewPrice, x.OldPrice })
                                            .ToList();
            return Json(products);
        }
    }
}
