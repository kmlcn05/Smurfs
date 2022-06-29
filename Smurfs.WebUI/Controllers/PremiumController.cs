using Microsoft.AspNetCore.Mvc;

namespace Smurfs.WebUI.Controllers
{
    public class PremiumController : Controller
    {
        public IActionResult Premium()
        {
            return View();
        }
    }
}
