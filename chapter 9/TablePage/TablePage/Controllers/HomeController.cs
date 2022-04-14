using Microsoft.AspNetCore.Mvc;
using TablePage.Models;
using TablePage.Services;

namespace TablePage.Controllers
{
    public class HomeController : Controller
    {
        private int PageSize = 5; //Количесво записей на странице
        private IPersons _persons;
        public HomeController(IPersons persons)
        {
            _persons = persons;
        }
        public IActionResult Index(int? elementPage)
        {
            var query = _persons.Persons;
            PagingInfo p = new PagingInfo()
            {
                CurrentPage = elementPage ?? 1,
                ItemsPerPage = PageSize,
                TotalItems = query.Count()
            };
            ViewBag.PageInfo = p;
            query = query.OrderBy(x => x.Id).Skip((p.CurrentPage - 1) * PageSize).Take(PageSize).ToList();
            return View(query);
        }
    }
}
