using Microsoft.AspNetCore.Mvc;

namespace Smurfs.WebUI.Controllers
{
    public class IndexPageController : Controller
    {
        public IActionResult AnaSayfa()
        {
            return View();
        }
    }
}
