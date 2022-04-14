using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TrainingCourses.Models;

namespace SessionState.Controllers
{
    public class HomeController : Controller
    {
        const string SessionName = "_Name";
        const string SessionAge = "_Age";
        const string SessionPerson = "_Person";
        public IActionResult Index()
        {
            HttpContext.Session.SetString(SessionName, "Stan");
            HttpContext.Session.SetInt32(SessionAge, 50);
            var person = new Person() { Name = "Stan", Age = 50 };
            HttpContext.Session.SetString(SessionPerson, JsonSerializer.Serialize<Person>(person));
            return View();
        }
        public IActionResult About()
        {
            ViewBag.Name = HttpContext.Session.GetString(SessionName);
            ViewBag.Age = HttpContext.Session.GetInt32(SessionAge);
            ViewData["Message"] = "Обо мне";
            return View();
        }
        public IActionResult Person()
        {
            var value = HttpContext.Session.GetString(SessionPerson);
            var person = value == null ? default(Person) : JsonSerializer.Deserialize<Person>(value);
            ViewData["Message"] = "Субъект";
            return View(person);
        }
    }
}
