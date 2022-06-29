using Microsoft.AspNetCore.Mvc;

namespace Smurfs.WebUI.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Team()
        {
            return View();
        }
    }
}
