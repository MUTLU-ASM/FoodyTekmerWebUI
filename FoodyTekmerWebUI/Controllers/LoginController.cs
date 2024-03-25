using FoodyTekmerBusinessLayer.Abstract;
using FoodyTekmerEntityLayer.Concrete;
using FoodyTekmerWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace FoodyTekmerWebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
        IToastNotification _notification;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,IToastNotification toastNotification)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_notification = toastNotification;

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
		[HttpPost]
		public async Task<IActionResult> SignIn(UserSignInViewModel u)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(u.username, u.password, false, true);
				if (result.Succeeded)
				{
                    return RedirectToAction("Index", "Profile");
				}
				else
				{
                    _notification.AddErrorToastMessage(message: $"Hatalı giriş");
                    ModelState.AddModelError(string.Empty, "Geçersiz giriş ! Lütfen tekrar deneyiniz.");
                    return View(u);
                }
			}
			return View();
		}
	}
}
