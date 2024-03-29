﻿using FoodyTekmerBusinessLayer.Abstract;
using FoodyTekmerDataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FoodyTekmerWebUI.ViewComponents
{
    public class ProductListCategoryComponentPartial:ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public ProductListCategoryComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _categoryService.TGetAllList().Take(3).ToList();
            return View(values);
        }
    }
}
