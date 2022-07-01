using Microsoft.AspNetCore.Mvc;

namespace Smurfs.WebUI.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Manager()
        {
            ViewBag.Username = HttpContext.Session.GetString("LoggedUserMail");

            return View();
        }
    }
}
