using FoodyTekmerBusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FoodyTekmerWebUI.ViewComponents
{
    public class AdminHomeContactComponentPartial:ViewComponent
    {
        private readonly IContactService _contactService;

        public AdminHomeContactComponentPartial(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _contactService.TGetAllList().OrderByDescending(x=>x.dateTime).Take(4).ToList();
            return View(values);
        }
    }
}
