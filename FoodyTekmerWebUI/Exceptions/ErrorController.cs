using Microsoft.AspNetCore.Mvc;

namespace FoodyTekmerWebUI.Exceptions
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/StatusCodeError/{statusCode}")]
        public IActionResult Errors(int statusCode)
        {

           ViewBag.ErrorMessage = statusCode;

            return View();
        }
    }
}
