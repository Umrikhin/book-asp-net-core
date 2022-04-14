using AutoComplete.Models;
using AutoComplete.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoComplete.Controllers
{
    public class HomeController : Controller
    {
        private IPersons _persons;
        public HomeController(IPersons persons)
        {
            _persons = persons;
        }
        public IActionResult Index(string? search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var data = _persons.people.Where(x => x.FIO.ToLower().Contains(search.ToLower())).ToList();
                if (data.Count > 0)
                {
                    return View(data);
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Find()
        {
            var name = HttpContext.Request.Query["frarment"].ToString();
            var data = _persons.people.Where(x => x.FIO.ToLower().Contains(name.ToLower())).ToList();
            return Ok(data);
        }
        [HttpPost]
        public IActionResult Search(string search)
        {
            //Логика поиска
            return RedirectToAction("Index", "Home", new { search = search });
        }
    }
}
