﻿using FoodyTekmerBusinessLayer.Abstract;
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
		private readonly SignInManager<AppUser> _signInManager;

		public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
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
					return RedirectToAction("SignIn", "Login");
				}
			}
			return View();
		}
	}
}
