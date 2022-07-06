using Microsoft.AspNetCore.Mvc;

namespace Smurfs.WebUI.Controllers
{
    public class SifreDegistirController : Controller
    {
        public IActionResult SifreDegistir()
        {

            ViewBag.Username = HttpContext.Session.GetString("LoggedUser");
            ViewBag.Usergruop = HttpContext.Session.GetString("UserRole");
            ViewBag.UserId = HttpContext.Session.GetString("Id");

            return View();

        
        }
    }
}
