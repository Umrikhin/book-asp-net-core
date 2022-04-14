using Microsoft.AspNetCore.Mvc;
using TableGroup.Models;
using TableGroup.Services;

namespace TableGroup.Controllers
{
    public class HomeController : Controller
    {
        private IOffices _offices;
        public HomeController(IOffices offices)
        {
            _offices = offices;
        }
        public IActionResult Index()
        {
            return View(_offices.Offices);
        }
    }
}
