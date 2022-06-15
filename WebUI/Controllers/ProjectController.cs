using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ILogger<ProjectController> _project;

        public ProjectController(ILogger<ProjectController> project)
        {
            _project = project;
        }
        public IActionResult Project()
        {
            return View();
        }
    }
}
