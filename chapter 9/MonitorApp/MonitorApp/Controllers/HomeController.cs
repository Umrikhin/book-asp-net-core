using Microsoft.AspNetCore.Mvc;
using MonitorApp.Services;

namespace MonitorApp.Controllers
{
    public class HomeController : Controller
    {
        private IMonitorPanel _monitor;
        public HomeController(IMonitorPanel monitor)
        {
            _monitor = monitor;
        }
        public IActionResult Index()
        {
            return View(_monitor.GetAll().OrderByDescending(x => x.Id).ToList());
        }
    }
}
