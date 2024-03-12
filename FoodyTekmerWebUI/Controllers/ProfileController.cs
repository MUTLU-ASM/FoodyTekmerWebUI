using FoodyTekmerEntityLayer.Concrete;
using FoodyTekmerWebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodyTekmerWebUI.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
		[HttpGet]
		public async Task<IActionResult> Index()
        {
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			UserEditViewModel userEditViewModel = new UserEditViewModel();
			userEditViewModel.name = values.Name;
			userEditViewModel.surName = values.Surname;
			userEditViewModel.phoneNumber = values.PhoneNumber;
			userEditViewModel.mail = values.Email;
			userEditViewModel.imageUrl = values.ImageUrl;
			ViewBag.img = values.ImageUrl;
			return View(userEditViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> ProfileSetting()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.name = values.Name;
            userEditViewModel.surName = values.Surname;
            userEditViewModel.phoneNumber = values.PhoneNumber;
            userEditViewModel.mail = values.Email;
            userEditViewModel.imageUrl = values.ImageUrl;
            ViewBag.img = values.ImageUrl;
            return View(userEditViewModel);
        }
    }
}
