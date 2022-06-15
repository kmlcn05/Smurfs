using Microsoft.AspNetCore.Mvc;
using Smurfs.Business.Abstract;
using Smurfs.DataAccess.Abstract;
using Smurfs.Entities.Conrete;

namespace Smurfs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController:ControllerBase
    {
            
            private IProjectService _projectService;

            public ProjectController(IProjectService projectService)
            {
                _projectService = projectService;
            }

            // GET: api/<ProjectController>
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var Project = _projectService.GetAllProjects();
                return Ok(Project);
            }

            // GET api/<ProjectController>/5
            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(long Id)
            {
                var p = _projectService.GetProjectById(Id);
                if (p == null)
                {
                    return NotFound();
                }

                return Ok(p);
            }

            // POST api/<ProjectController>/5
            [HttpPost]
                public IActionResult SaveProject([FromBody] Project project)
                {
                    _projectService.SaveProject(project);
                    return Ok(project);
                }

            // PUT api/<ProjectController>/5
            [HttpPut]
                public IActionResult Update([FromBody] Project project)
                {
                    _projectService.UpdateProject(project);
                    return Ok(project);
                }

            // DELETE api/<ProjectController>/5
            [HttpDelete]
                public IActionResult Delete([FromBody] long projectId)
                {
                    _projectService.DeleteProject(projectId);
                    return Ok("Silindi");
                }

            [HttpPost]
                public IActionResult Calculate([FromBody] long projectId)
                {
                    _projectService.Calculate(projectId);
                    return Ok("Hesaplamalar doğru şekilde yapıldı");
                }
    }
}
