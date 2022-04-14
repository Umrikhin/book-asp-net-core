using FiltersSample.Utils;
using Microsoft.AspNetCore.Mvc;

namespace FiltersSample.Controllers
{
    public class HomeController : Controller
    {
        [BrowserFilterAsync]
        [ExampleFilter(Order = 1)]
        [SimpleFilterAsync("user")]
        //[ServiceFilter(typeof(ConfigFilterAsync))]
        [TypeFilter(typeof(ConfigFilterAsync))]
        public IActionResult Index()
        {
            return View();
        }
    }
}
