using Microsoft.AspNetCore.Mvc;

namespace HelloRazor.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
