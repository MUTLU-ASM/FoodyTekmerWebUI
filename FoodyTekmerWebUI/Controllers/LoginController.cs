using FoodyTekmerBusinessLayer.Abstract;
using FoodyTekmerEntityLayer.Concrete;
using FoodyTekmerWebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodyTekmerWebUI.Controllers
{
    public class LoginController : Controller
    {
        //private readonly SignInManager<Admin> _signInManager;

        //public LoginController(SignInManager<Admin> signInManager)
        //{
        //    _signInManager = signInManager;
        //}
        //[HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> Index(UserSignInViewModel user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, false);
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Index", "AdminHome");
        //        }
        //        else
        //        {
        //            return RedirectToAction("Index", "Login");
        //        }
        //    }
        //    return View();
        //}
    }
}
