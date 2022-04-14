using Microsoft.AspNetCore.Mvc;

namespace ComponentBlazor.Controllers
{
    public class HomeController: Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}
