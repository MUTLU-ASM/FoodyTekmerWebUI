using FoodyTekmerBusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FoodyTekmerWebUI.ViewComponents
{
    public class AdminHomeAboutComponentPartial : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public AdminHomeAboutComponentPartial(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _aboutService.TGetAllList().Take(3).ToList();
            return View(values);
        }
    }
}
