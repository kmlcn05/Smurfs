using Microsoft.AspNetCore.Mvc;

namespace Smurfs.WebUI.Controllers
{
    public class AdminIndexController : Controller
    {
        public IActionResult AdminIndex()
        {
            if (HttpContext.Session.GetString("UserRole") == "Admin"
                || HttpContext.Session.GetString("UserRole") == "Manager")
            {
                ViewBag.Username = HttpContext.Session.GetString("LoggedUser");

                return View();
            }
            else
                return View("NotAuthorized");
        }
    }
}
