using Microsoft.AspNetCore.Mvc;
using Smurfs.WebUI.Services;

namespace Smurfs.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private ILoginService _loginService { get; set; }
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        public IActionResult Login()
        {
            HttpContext.Session.Clear();
            return View();
        }
        public IActionResult Anasayfa()
        {
            if (HttpContext.Session.GetString("UserRole") == "Developer"
               || HttpContext.Session.GetString("UserRole") == "Analyst")
            {
                ViewBag.Username = HttpContext.Session.GetString("LoggedUser");
                ViewBag.Usermail = HttpContext.Session.GetString("Usermail");
                ViewBag.Usergruop = HttpContext.Session.GetString("UserRole");

                return View();
            }
            else
                return View("NotAuthorized");
        }

        [HttpPost]
        public IActionResult LoginUser(string mail, string password)
        {
            var account = _loginService.LoginAsync(mail, password);

            if (account != null && password != null && mail != null)
            {
                if (string.IsNullOrEmpty(account.Result.Name))
                {
                    ViewBag.msg = "*Geçersiz kullanıcı adı veya şifre";
                    return View("Login");
                }
                else
                {
                    HttpContext.Session.SetString("LoggedUser", account.Result.Name + " " + account.Result.Surname);
                    HttpContext.Session.SetString("UserRole", account.Result.UserGroup +"");
                    HttpContext.Session.SetString("Usermail", account.Result.Mail + "");

                    if (HttpContext.Session.GetString("UserRole") == "Admin")
                    {
                        return RedirectToAction("Admin", "Admin");
                    }
                    else if (HttpContext.Session.GetString("UserRole") == "Manager")
                    {
                        return RedirectToAction("Manager", "Manager");
                    }
                    else
                    {
                        return RedirectToAction("Anasayfa");
                    }
                }
            }
            else
            {
                ViewBag.msg = "Invalid";
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult LogoutUser()
        {
            HttpContext.Session.Clear();

            return View("Login");
        }

    }
}
