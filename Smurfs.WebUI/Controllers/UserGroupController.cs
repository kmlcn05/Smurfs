using Microsoft.AspNetCore.Mvc;

namespace Smurfs.WebUI.Controllers
{
    public class UserGroupController : Controller
    {
        public IActionResult UserGroup()
        {
            return View();
        }
    }
}
