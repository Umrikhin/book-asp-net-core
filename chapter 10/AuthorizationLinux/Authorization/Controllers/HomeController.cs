using Authorization.Models;
using Authorization.Services;
using Authorization.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Authorization.Controllers
{
    public class HomeController : Controller
    {
        private IUsersPortalRepository _repositoryUsers;
        public HomeController(IUsersPortalRepository repoUsersPortal)
        {
            _repositoryUsers = repoUsersPortal;
        }
        [AuthorizationFilter]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserId");
            DeleteCookie();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginUser login)
        {
            if (ModelState.IsValid)
            {   
                try
                {
                    var users = _repositoryUsers.UsersPortal;
                    int currentUserId = 0;
                    if (users.Where(x => x.UserName == login.User && x.Password == login.Password).Count() > 0)
                    {
                        var user = users.Where(x => x.UserName == login.User && x.Password == login.Password).FirstOrDefault();
                        currentUserId = user != null ? user.Id : 0;
                        HttpContext.Session.SetString("UserId", currentUserId.ToString());
                        SaveCookie(currentUserId.ToString());
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Пользователь не существует. Вход невозможен!");
                        return View("Login", login);
                    }
                }
                catch (Exception err)
                {
                    ModelState.AddModelError("", err.Message);
                    return View("Login", login);
                }
            }
            else
            {
                return View("Login", login);
            }
        }
        private void SaveCookie(string UserId)
        {
            try
            {
                if (!Request.Cookies.ContainsKey("UserId"))
                {
                    CookieOptions option = new CookieOptions();
                    option.Expires = DateTime.Now.AddDays(3);
                    Response.Cookies.Append("UserId", UserId, option);
                }
            }
            catch
            {

            }
        }
        private void DeleteCookie()
        {
            try
            {
                Response.Cookies.Delete("UserId");
            }
            catch
            {

            }
        }
    }
}
