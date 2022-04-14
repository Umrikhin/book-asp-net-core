using Microsoft.AspNetCore.Mvc;
using TableCRUD.Models;
using TableCRUD.Services;

namespace TableCRUD.Controllers
{
    public class HomeController : Controller
    {
        private ILands _lands;
        public HomeController(ILands lands)
        {
            _lands = lands;
        }
        public IActionResult Index(int rowUpdate = 0)
        {
            ViewBag.RowUpdate = rowUpdate;
            return View(_lands.lands.OrderByDescending(x => x.Id).ToList());
        }
        [HttpPost]
        public IActionResult EditLand(string NameLandForRow, int saveId = 0)
        {
            if (saveId > 0)
            {
                try
                {   
                    _lands.EditCountry(new Country() { Id = saveId, CountryName = NameLandForRow });
                }
                catch (Exception err)
                {
                    ModelState.AddModelError("", err.Message);
                    return View("Index", _lands.lands.OrderByDescending(x => x.Id).ToList());
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Выберите запись, чтобы сохранить изменение.");
            }
            return View("Index", _lands.lands.OrderByDescending(x => x.Id).ToList());
        }
        [HttpPost]
        public IActionResult DeleteLand(int deleteId = 0, int saveId = 0)
        {
            try
            {
                var land = _lands.lands.Where(x => x.Id == deleteId).FirstOrDefault();
                if (land != null)
                {
                    _lands.DeleteCountry(land);
                    TempData["messageDelInfo"] = "Запись по " + land.CountryName + " успешно удалена!";
                }
            }
            catch (Exception err)
            {
                TempData["messageDelErr"] = err.Message;
            }
            return saveId == 0 | deleteId == saveId ? RedirectToAction("Index", "Home") : RedirectToAction("Index", "Home", new { rowUpdate = saveId });
        }
        [HttpPost]
        public IActionResult CancelUpdateLand()
        {
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult UpdateLand(int updateId = 0)
        {
            return RedirectToAction("Index", "Home", new { rowUpdate = updateId });
        }
        [HttpPost]
        public IActionResult AddLand(string NameLand)
        {
            if (!string.IsNullOrEmpty(NameLand))
            {
                try
                {
                    _lands.AddCountry(new Country() { Id = 0, CountryName = NameLand });
                }
                catch (Exception err)
                {
                    ModelState.AddModelError("", err.Message);
                    return View("Index", _lands.lands.OrderByDescending(x => x.Id).ToList());
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Внесите наименование страны.");
            }
            return View("Index", _lands.lands.OrderByDescending(x => x.Id).ToList());
        }
    }
}
