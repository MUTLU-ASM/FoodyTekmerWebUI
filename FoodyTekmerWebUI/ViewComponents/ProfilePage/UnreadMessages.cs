using FoodyTekmerBusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FoodyTekmerWebUI.ViewComponents.ProfilePage
{
    public class UnreadMessages:ViewComponent
    {
        private readonly IContactService _contactService;

        public UnreadMessages(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IViewComponentResult Invoke()
        {
            var unreadCount = _contactService.GetListUnreadMessage().Count;
            ViewBag.unreadCount = unreadCount;
            var values = _contactService.GetListUnreadMessage();
            return View(values);
        }
    }
}
