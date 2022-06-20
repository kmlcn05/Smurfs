﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Anasayfa()
        {
            ViewBag.Username = HttpContext.Session.GetString("LoggedUserMail");

            if (string.IsNullOrEmpty(ViewBag.Username))
            {
                return View("Anasayfa");
            }

            return View();
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
                    HttpContext.Session.SetString("LoggedUserMail", account.Result.Name + " " + account.Result.Surname);
                    //ViewBag.Username = account.Result.Name + " " + account.Result.Surname;
                    return RedirectToAction("Anasayfa");
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
