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
			return View(values);
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
        [HttpPost]
        public async Task<IActionResult> ProfileSetting(UserEditViewModel u)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (u.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(u.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/userimages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await u.Image.CopyToAsync(stream);
                user.ImageUrl = "/userimages/" + imagename;
            }
            user.Name = u.name;
            user.Surname = u.surName;
            user.Email = u.mail;
            user.PhoneNumber = u.phoneNumber;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, u.password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Profile");
            }
            return View();
        }
    }
}
