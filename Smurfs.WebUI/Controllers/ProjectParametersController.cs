using Microsoft.AspNetCore.Mvc;

namespace Smurfs.WebUI.Controllers
{
    public class ProjectParametersController : Controller
    {
        public IActionResult ProjectParameters()
        {
            return View();
        }
    }
}
