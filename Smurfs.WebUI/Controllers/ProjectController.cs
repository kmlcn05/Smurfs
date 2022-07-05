using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Smurfs.Entities.Conrete;
using Smurfs.WebUI.Services.Interfaces;

namespace WebUI.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectService _projectService { get; set; }
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        public IActionResult Project()
        {
            if (HttpContext.Session.GetString("UserRole") == "Admin"
                || HttpContext.Session.GetString("UserRole") == "Manager"
                && HttpContext.Session.GetString("FirstLogin") == "0")
            {
                ViewBag.Username = HttpContext.Session.GetString("LoggedUser");
                ViewBag.Usergruop = HttpContext.Session.GetString("UserRole");

                return View();
            }
            else
                return View("NotAuthorized");
        }
        public IActionResult ProjectU()
        {
            if (HttpContext.Session.GetString("UserRole") == "Analyst"
                 || HttpContext.Session.GetString("UserRole") == "Developer"
                 && HttpContext.Session.GetString("FirstLogin") == "0")
            {
                ViewBag.Username = HttpContext.Session.GetString("LoggedUser");

                return View();
            }
            else
                return View("NotAuthorized");
        }

        public async Task<IActionResult> GetProjectsFromAPI()
        {
            var projects = new List<Project>();

            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync("https://smuhammetulas.com/api/Project"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    projects = JsonConvert.DeserializeObject<List<Project>>(apiResponse);
                }
            }
            return View("Project",projects);
        }
    }
}
