using RadioButtonList.Models;
using RadioButtonList.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RadioButtonList.Controllers
{
    public class HomeController : Controller
    {
        private IFruits _fruits;
        public HomeController(IFruits fruits)
        {
            _fruits = fruits;
        }
        public IActionResult Index()
        {
            List<SelectListItem> items = GetFruits();
            return View(items);
        }
        [HttpPost]
        public IActionResult Сhoose(string Fruit)
        {
            List<SelectListItem> items = GetFruits();
            var selectedItem = items.Find(p => p.Value == Fruit);
            if (selectedItem != null)
            {
                selectedItem.Selected = true;
                ViewBag.Message = "Выбрано: " + selectedItem.Text;
            }
            return View("Index", items);
        }
        private List<SelectListItem> GetFruits()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach(var row in _fruits.fruits ?? new List<Fruit>())
            {
                items.Add(new SelectListItem
                {
                    Text = row.nm,
                    Value = row.id.ToString()
                });
            }
            return items;
        }
    }
}
