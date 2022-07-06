using Microsoft.AspNetCore.Mvc;

namespace Smurfs.WebUI.Controllers
{
    public class GeneralPremiumController : Controller
    {
        public IActionResult GeneralPremium()
        {
            if (HttpContext.Session.GetString("UserRole") == "Manager"
                && HttpContext.Session.GetString("FirstLogin") == "0")
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
