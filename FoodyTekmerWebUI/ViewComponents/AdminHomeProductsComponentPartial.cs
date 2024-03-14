using FoodyTekmerBusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FoodyTekmerWebUI.ViewComponents
{
    public class AdminHomeProductsComponentPartial:ViewComponent
    {
        private readonly IProductService _productService;

        public AdminHomeProductsComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _productService.TGetListCategory().Take(4).ToList();
            return View(values);
        }
    }
}
