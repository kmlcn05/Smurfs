using Microsoft.AspNetCore.Mvc;

namespace Smurfs.WebUI.Controllers
{
    public class AdminIndexController : Controller
    {
        public IActionResult AdminIndex()
        {
            return View();
        }
    }
}
