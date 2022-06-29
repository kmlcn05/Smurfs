using Microsoft.AspNetCore.Mvc;

namespace Smurfs.WebUI.Controllers
{
    public class StatusController : Controller
    {
        public IActionResult Status()
        {
            return View();
        }
    }
}
