﻿using FeedBack.Infrastructure;
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
                if (!sendForm.IsАssent)
                {
                    ModelState.AddModelError("", "Не отмечено согласие на обработку данных!");
                    return View("Index", sendForm);
                }
                if (sendForm.CaptchaCode != HttpContext.Session.GetString("CaptchaCode"))
                {
                    ModelState.AddModelError("", "Ошибочный код: Попробуйте еще раз!");
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

        [HttpGet]
        [Route("get-captcha-image")]
        public IActionResult GetCaptchaImage()
        {
            var captchaCode = GenerateRandomCode();
            CaptchaImage ci = new CaptchaImage(captchaCode, 200, 50);
            HttpContext.Session.SetString("CaptchaCode", captchaCode);
            Stream s = ci.image.Encode(SkiaSharp.SKEncodedImageFormat.Jpeg, 100).AsStream();
            ci.Dispose();
            s.Position = 0;
            return new FileStreamResult(s, "image/jpeg");
        }

        private Random random = new Random();
        private string GenerateRandomCode()
        {
            string s = "";
            for (int i = 0; i < 6; i++)
                s = String.Concat(s, this.random.Next(10).ToString());
            return s;
        }
    }
}
