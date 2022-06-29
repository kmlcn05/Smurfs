using Microsoft.AspNetCore.Mvc;

namespace Smurfs.WebUI.Controllers
{
    public class DZDStatusController : Controller
    {
        public IActionResult DZDStatus()
        {
            return View();
        }
    }
}
