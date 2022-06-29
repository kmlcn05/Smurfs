using Microsoft.AspNetCore.Mvc;

namespace Smurfs.WebUI.Controllers
{
    public class ProcessController : Controller
    {
        public IActionResult Process()
        {
            return View();
        }
    }
}
