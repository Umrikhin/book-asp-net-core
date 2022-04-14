using Microsoft.AspNetCore.Mvc;
using SiteDocs.Models;

namespace SiteDocs.Controllers
{
    public class HomeController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult IndexClass()
        {
            return View();
        }
        public IActionResult IndexMoreClass()
        {
            return View();
        }
        public string AcceptResult(int code, string title, string issuedBy)
        {
            Doc doc = new Doc()
            {
                Code = code,
                Title = title,
                IssuedBy = issuedBy
            };
            return $"Код документа: {doc.Code}. Наименование: {doc.Title}. Кем выдан: {doc.IssuedBy}.";
        }
        public string AcceptResultClass(Doc doc)
        {
            return $"Код документа: {doc.Code}. Наименование: {doc.Title}. Кем выдан: {doc.IssuedBy}.";
        }
        public string AcceptResultMoreClass(Doc[] docs)
        {
            string result = "";
            foreach (Doc doc in docs)
                result += $"Код документа: {doc.Code}. Наименование: {doc.Title}. Кем выдан: {doc.IssuedBy}.\n";
            return result;
        }
    }
}
