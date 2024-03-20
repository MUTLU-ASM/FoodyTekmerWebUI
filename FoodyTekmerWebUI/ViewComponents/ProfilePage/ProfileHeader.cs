using FoodyTekmerEntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodyTekmerWebUI.ViewComponents.ProfilePage
{
    public class ProfileHeader:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileHeader(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(values);
        }
    }
}
