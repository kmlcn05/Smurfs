using Microsoft.AspNetCore.Mvc;
using Smurfs.WebUI.Models;
using System.Diagnostics;

namespace Smurfs.WebUI.Controllers
{
    public class AdminController : Controller
    {

        public IActionResult Admin()
        {
            ViewBag.Username = HttpContext.Session.GetString("LoggedUserMail");

            return View("Admin");

        }

    }
}

