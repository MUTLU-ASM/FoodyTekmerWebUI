using FluentValidation.Results;
using FoodyTekmerBusinessLayer.Abstract;
using FoodyTekmerBusinessLayer.ValidationRules;
using FoodyTekmerDataAccessLayer.Context;
using FoodyTekmerEntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using X.PagedList;

namespace FoodyTekmerWebUI.Controllers
{
    public class CategoryController : Controller
    {
        IToastNotification _notification;

        public CategoryController(IToastNotification notification)
        {
            _notification = notification;
        }

        FoodyContext context = new FoodyContext();

        public IActionResult Index(int page = 1)
        {
            var values = context.Categories.ToList().ToPagedList(page, 5);
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Category c)
        {
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult result = validationRules.Validate(c);
            if (result.IsValid)
            {
                _notification.AddSuccessToastMessage(message: $"{c.CategoryName} Başarılı şekilde eklenmiştir.");
                context.Categories.Add(c);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var x in result.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
                _notification.AddErrorToastMessage(message: $"{c.CategoryName} Eklenmemiştir.");
                return View();
            }

        }
        public IActionResult DeleteCategory(int id)
        {
            var value = context.Categories.Find(id);
            context.Categories.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var value = context.Categories.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category c)
        {
            _notification.AddSuccessToastMessage(message: $"{c.CategoryName} Başarılı şekilde güncellenmiştir.");
            context.Categories.Update(c);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
