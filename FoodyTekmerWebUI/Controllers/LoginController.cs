using FoodyTekmerBusinessLayer.Abstract;
using FoodyTekmerEntityLayer.Concrete;
using FoodyTekmerWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodyTekmerWebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
		private readonly UserManager<AppUser> _userManager;

		public LoginController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
		[HttpPost]
		public async Task<IActionResult> SignUp(UserRegisterViewModel user)
		{
			AppUser appUser = new AppUser()
			{
				Name = user.Name,
				Surname = user.Surname,
				Email = user.Mail,
				UserName = user.Username
			};
			if (user.Password == user.ConfirmPassword)
			{
				var result = await _userManager.CreateAsync(appUser, user.Password);
				if (result.Succeeded)
				{
					return RedirectToAction("SignIn");
				}
				else
				{
					foreach (var x in result.Errors)
					{
						ModelState.AddModelError("", x.Description);
					}
				}
			}
			return View(user);
		}
		[HttpGet]
		public IActionResult SignIn()
		{
			return View();
		}
	}
}
