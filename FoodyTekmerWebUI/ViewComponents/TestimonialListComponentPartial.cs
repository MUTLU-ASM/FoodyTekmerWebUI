using FoodyTekmerBusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FoodyTekmerWebUI.ViewComponents
{
    public class TestimonialListComponentPartial : ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialListComponentPartial(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _testimonialService.TGetAllList();
            return View(values);
        }
    }
}
