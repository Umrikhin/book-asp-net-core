using Dropdownlist.Models;
using Dropdownlist.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dropdownlist.Controllers
{
    public class HomeController : Controller
    {
        private IRegions _regions;
        public HomeController(IRegions regions)
        {
            _regions = regions;
        }
        public IActionResult Index(int idLand = 0)
        {
            ViewBag.Land = GetCountryForSelect();
            List<City> cities = _regions.towns;
            if (idLand > 0) cities = cities.Where(x => x.idLand == idLand).ToList();
            return View(new ViewLand() { idLand = idLand, cities = cities });
        }
        Microsoft.AspNetCore.Mvc.Rendering.SelectList GetCountryForSelect()
        {
            var lands = _regions.countrys;
            if (lands.Where(x => x.id == 0).Count() == 0) lands.Add(new Land() { id = 0, nm = "Все страны" });
            return new Microsoft.AspNetCore.Mvc.Rendering.SelectList(lands.OrderBy(x => x.id), "id", "nm");
        }
        [HttpPost]
        public IActionResult Select(int Country)
        {
            return RedirectToAction("Index", "Home", new { idLand = Country });
        }
    }
}
