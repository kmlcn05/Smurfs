using Microsoft.AspNetCore.Mvc;
using Smurfs.WebUI.Models;
using System.Diagnostics;

namespace Smurfs.WebUI.Controllers
{
    public class AdminController : Controller
    {

        public IActionResult Admin()
        {
            if (HttpContext.Session.GetString("UserRole") == "Admin"
                || HttpContext.Session.GetString("UserRole") == "Manager")
            {
                ViewBag.Username = HttpContext.Session.GetString("LoggedUser");
                ViewBag.Usergruop = HttpContext.Session.GetString("UserRole");

                return View();
            }
            else
                return View("NotAuthorized");
        }

    }
}


