using AjaxForm.Models;
using Microsoft.AspNetCore.Mvc;

namespace AjaxForm.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendData(Person person)
        {
            System.Threading.Thread.Sleep(5000);
            if (person.TestError > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Json(person);
        }
    }
}
