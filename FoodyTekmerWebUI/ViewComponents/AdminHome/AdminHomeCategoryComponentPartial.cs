using FoodyTekmerBusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FoodyTekmerWebUI.ViewComponents.AdminHome
{
    public class AdminHomeCategoryComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public AdminHomeCategoryComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _categoryService.TGetAllList().Take(5).ToList();
            return View(values);
        }
    }
}
