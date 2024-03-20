using FoodyTekmerBusinessLayer.Abstract;
using FoodyTekmerDataAccessLayer.Context;
using FoodyTekmerEntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace FoodyTekmerWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult Index(int page = 1)
        {
            var values = _productService.TGetListCategory().ToPagedList(page, 7);
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            List<SelectListItem> categoryList = (from x in _categoryService.TGetAllList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.categoryList = categoryList;
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            product.Status = true;
            _productService.TAdd(product);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteProduct(int id)
        {
            var product = _productService.TGetById(id);
            if (product != null)
            {
                product.Status = product.Status == false ? true : false;
                _productService.TUpdate(product);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var values = _productService.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            product.Status = true;
            _productService.TUpdate(product);
            return RedirectToAction("Index");
        }
    }
}
