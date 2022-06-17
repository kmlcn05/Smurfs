using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class IndexPageController : Controller
    {
        public IActionResult AnaSayfa()
        {
            return View();
        }
    }
}
