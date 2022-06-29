using Microsoft.AspNetCore.Mvc;

namespace Smurfs.WebUI.Controllers
{
    public class CallStatusController : Controller
    {
        public IActionResult CallStatus()
        {
            return View();
        }
    }
}
