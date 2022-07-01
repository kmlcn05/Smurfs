using Microsoft.AspNetCore.Mvc;

namespace Smurfs.WebUI.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Manager()
        {
            if (HttpContext.Session.GetString("UserRole") == "Manager")
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
