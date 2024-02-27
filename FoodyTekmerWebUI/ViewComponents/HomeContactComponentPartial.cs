using Microsoft.AspNetCore.Mvc;

namespace FoodyTekmerWebUI.ViewComponents
{
    public class HomeContactComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
