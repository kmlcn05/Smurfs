using Microsoft.AspNetCore.Mvc;
using Smurfs.Business.Abstract;
using Smurfs.DataAccess.Abstract;
using Smurfs.Entities.Conrete;
using Smurfs.Entity.DTO_s;

namespace Smurfs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        private IProjectService _projectService;

            public ProjectController(IProjectService projectService)
            {
                _projectService = projectService;
            }

        // GET: api/<ProjectController>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var Project = await _projectService.GetAll();
            return Ok(Project);
        }

        // GET api/<ProjectController>/5
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int Id)
        {
            var p = await _projectService.GetById(Id);
            if (p == null)
            {
                return NotFound();
            }

            return Ok(p);
        }

        // POST api/<ProjectController>/5
        [HttpPost("Save")]
        public IActionResult SaveProject([FromBody] GetProjectsDto project)
        {
            _projectService.Create(project);
            return Ok(project);
        }

        // PUT api/<ProjectController>/5
        [HttpPut("Update")]
        public IActionResult Update([FromBody] GetProjectsDto project)
        {
            _projectService.Update(project);
            return Ok(project);
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] Project project)
        {
            _projectService.Delete(project);
            return Ok("Silindi");
        }


        // CALCULATE api/<ProjectController>/5
        [HttpPost("Calculate")]
        public IActionResult Calculate([FromBody] int projectId)
        {
            _projectService.Calculate(projectId);
            return Ok("Hesaplamalar doğru şekilde yapıldı");
        }

        [HttpGet("GetProjects")]
        public IActionResult GetProjects()
        {
            var Project = _projectService.GetProjectsDetails();
            return Ok(Project);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> DeleteProject(int id)
        {
            try
            {
                var employeeToDelete = await _projectService.GetById(id);

                if (employeeToDelete == null)
                {
                    return NotFound($"Project with Id = {id} not found");
                }

                return await _projectService.DeleteProject(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

    }
}
