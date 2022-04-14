using Microsoft.AspNetCore.Mvc;
using TableSort.Infrastructure;
using TableSort.Models;
using TableSort.Services;

namespace TableSort.Controllers
{
    public class HomeController : Controller
    {
        private IPersons _persons;
        public HomeController(IPersons persons)
        {
            _persons = persons;
        }
        public IActionResult Index(SortStatus orderBy = SortStatus.IdAsc)
        {
            var people = _persons.GetAll() ?? new List<Person>();
            ViewBag.IdSort = orderBy == SortStatus.IdAsc ? SortStatus.IdDesc : SortStatus.IdAsc;
            ViewBag.FirstNameSort = orderBy == SortStatus.FirstNameAsc ? SortStatus.FirstNameDesc : SortStatus.FirstNameAsc;
            ViewBag.LastNameSort = orderBy == SortStatus.LastNameAsc ? SortStatus.LastNameDesc : SortStatus.LastNameAsc;
            ViewBag.DateOfBirthSort = orderBy == SortStatus.DateOfBirthAsc ? SortStatus.DateOfBirthDesc : SortStatus.DateOfBirthAsc;
            ViewBag.IconIdSort = "↕";
            ViewBag.IconFirstNameSort = "↕";
            ViewBag.IconLastNameSort = "↕";
            ViewBag.IconDateOfBirthSort = "↕";
            switch (orderBy)
            {
                case SortStatus.IdDesc:
                    ViewBag.IconIdSort = "↓";
                    break;
                case SortStatus.FirstNameAsc:
                    ViewBag.IconFirstNameSort = "↑";
                    break;
                case SortStatus.FirstNameDesc:
                    ViewBag.IconFirstNameSort = "↓";
                    break;
                case SortStatus.LastNameAsc:
                    ViewBag.IconLastNameSort = "↑";
                    break;
                case SortStatus.LastNameDesc:
                    ViewBag.IconLastNameSort = "↓";
                    break;
                case SortStatus.DateOfBirthAsc:
                    ViewBag.IconDateOfBirthSort = "↑";
                    break;
                case SortStatus.DateOfBirthDesc:
                    ViewBag.IconDateOfBirthSort = "↓";
                    break;
                default:
                    ViewBag.IconIdSort = "↑";
                    break;
            };
            people = orderBy switch
            {
                SortStatus.IdDesc => people.OrderByDescending(s => s.Id),
                SortStatus.FirstNameAsc => people.OrderBy(s => s.FirstName),
                SortStatus.FirstNameDesc => people.OrderByDescending(s => s.FirstName),
                SortStatus.LastNameAsc => people.OrderBy(s => s.LastName),
                SortStatus.LastNameDesc => people.OrderByDescending(s => s.LastName),
                SortStatus.DateOfBirthAsc => people.OrderBy(s => s.DateOfBirth),
                SortStatus.DateOfBirthDesc => people.OrderByDescending(s => s.DateOfBirth),
                _ => people.OrderBy(s => s.Id),
            };
            return View(people.ToList());
        }
    }
}
