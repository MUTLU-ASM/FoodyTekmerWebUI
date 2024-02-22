using FoodyTekmerBusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FoodyTekmerWebUI.ViewComponents
{
    public class ProductListComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public ProductListComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _productService.TGetAllList().Where(x=>x.Status==true).Take(6).ToList();
            return View(values);
        }
    }
}
