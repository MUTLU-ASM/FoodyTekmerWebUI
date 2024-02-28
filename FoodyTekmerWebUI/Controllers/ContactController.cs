using FoodyTekmerBusinessLayer.Abstract;
using FoodyTekmerEntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace FoodyTekmerWebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public IActionResult Index(int page = 1)
        {
            var values = _contactService.TGetAllList().ToPagedList(page, 5);
            return View(values);
        }
        public IActionResult DeleteContact(int id)
        {
            _contactService.TDelete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateContact(int id)
        {
           var value = _contactService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateContact(Contact contact)
        {
            contact.Status = true;
            _contactService.TUpdate(contact);
            return RedirectToAction("Index");
        }
    }
}
