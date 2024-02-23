using FoodyTekmerBusinessLayer.Abstract;
using FoodyTekmerDataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FoodyTekmerWebUI.ViewComponents
{
    public class ProductListCategoryComponentPartial:ViewComponent
    {
        private readonly ICategoryService _productService;
        public ProductListCategoryComponentPartial(ICategoryService productService)
        {
            _productService = productService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _productService.TGetAllList().Take(3).ToList();
            return View(values);
        }
    }
}
