using FeedBack.Infrastructure;
using FeedBack.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeedBack.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration _config;
        public HomeController(IConfiguration config)
        {
            _config = config;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Send(SendFormFeedback sendForm)
        {
            if (ModelState.IsValid)
            {
                if (!sendForm.IsAssent)
                {
                    ModelState.AddModelError("", "Не отмечено согласие на обработку данных!");
                    return View("Index", sendForm);
                }
                string reply = "Тема: <b>" + sendForm.Sbj + "</b>.<br/><br/>" + sendForm.MessageForSend;
                reply = reply + "<br />Отправитель: " + sendForm.IM + "<br/><hr><a href='mailto:" + sendForm.Email + "'>Ответить отправителю</a>";
                string err = string.Empty;
                err = Utils.SendMsg(reply, _config);
                if (err.Length > 0)
                {
                    ModelState.AddModelError("", err);
                    return View("Index", sendForm);
                }
                else
                {
                    TempData["SendMessage"] = "Ваше сообщение было отправлено.";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View("Index", sendForm);
            }
        }
    }
}
