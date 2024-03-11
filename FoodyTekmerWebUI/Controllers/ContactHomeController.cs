using FoodyTekmerBusinessLayer.Abstract;
using FoodyTekmerEntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodyTekmerWebUI.Controllers
{
	[AllowAnonymous]
	public class ContactHomeController : Controller
    {
        private readonly IContactService _contactService;

        public ContactHomeController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contact.dateTime = DateTime.Now;
            _contactService.TAdd(contact);
            return RedirectToAction("Index");
        }

    }
}
