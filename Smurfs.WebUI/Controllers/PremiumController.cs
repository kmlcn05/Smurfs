using Microsoft.AspNetCore.Mvc;

namespace Smurfs.WebUI.Controllers
{
    public class PremiumController : Controller
    {
        public IActionResult Premium()
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
