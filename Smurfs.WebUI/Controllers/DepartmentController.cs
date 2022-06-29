using Microsoft.AspNetCore.Mvc;

namespace Smurfs.WebUI.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Department()
        {
            return View();
        }
    }
}
