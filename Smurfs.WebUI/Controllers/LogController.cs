using Microsoft.AspNetCore.Mvc;

namespace Smurfs.WebUI.Controllers
{
    public class LogController : Controller
    {
        public IActionResult Log()
        {
            return View();
        }
    }
}
