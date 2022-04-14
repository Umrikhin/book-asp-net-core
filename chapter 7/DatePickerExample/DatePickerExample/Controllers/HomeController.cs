using Microsoft.AspNetCore.Mvc;

namespace DatePickerExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string selectedDate)
        {
            ViewBag.Message = "Выбрана дата: " + selectedDate;
            return View();
        }
    }
}
