using Microsoft.AspNetCore.Mvc;
using HelloHtmlHelpers.Models;

namespace HelloRazor.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Привет <b>из контроллера</b>";
            return View();
        }
        public IActionResult Book()
        {
            return View();
        }
        public string Add(Book book)
        {
            return $"Книга {book.Title} в количестве {book.Copies} экз. добавлена";
        }
    }
}
