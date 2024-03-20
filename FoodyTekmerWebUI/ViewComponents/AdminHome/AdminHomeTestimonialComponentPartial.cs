using FoodyTekmerBusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FoodyTekmerWebUI.ViewComponents.AdminHome
{
    public class AdminHomeTestimonialComponentPartial : ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public AdminHomeTestimonialComponentPartial(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _testimonialService.TGetAllList().Take(4).ToList();
            return View(values);
        }
    }
}
