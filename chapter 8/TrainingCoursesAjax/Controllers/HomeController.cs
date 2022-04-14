using Microsoft.AspNetCore.Mvc;

namespace HelloAjax.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult IndexAjax()
        {
            return View();
        }
        public IActionResult IndexMethods()
        {
            return View();
        }
        public IActionResult IndexParam()
        {
            return View();
        }
        public IActionResult Courses()
        {
            return View();
        }
    }
}
