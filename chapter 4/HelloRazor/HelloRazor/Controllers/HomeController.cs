using Microsoft.AspNetCore.Mvc;

namespace HelloRazor.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Hello()
        {
            return View();
        }
        public IActionResult Default()
        {
            //ViewData["DataContent"] = "Использование ViewData";
            //ViewBag.DataContentBag = "Использование ViewBag";
            //return View();
            TempData["DataContent"] = "Использование TempData";
            return RedirectToAction("Hello", "Home");
        }
    }
}
