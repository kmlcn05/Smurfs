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
            return View();
        }

        public IActionResult Welcome()
        {
            ViewBag.username = HttpContext.Session.GetString("LoggedUserMail");
            return View();
        }

        [HttpPost]
        public IActionResult LoginUser(string mail, string password)
        {
            var account = _loginService.LoginAsync(mail, password);

            if(account != null)
            {
                HttpContext.Session.SetString("LoggedUserMail", account.Result.Name + " " + account.Result.Surname);

                return RedirectToAction("Welcome");
            }
            else
            {
                ViewBag.msg = "Invalid";
                return View("Error");
            }
        }
    }
}
