using Microsoft.AspNetCore.Mvc;
using Smurfs.Business.Abstract;
using Smurfs.Entities.Conrete;
using Smurfs.Entity.Concrete;

namespace Smurfs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProjectParametersController : ControllerBase
    {
        
        private IProjectParametersService _projectParametersService;

        public ProjectParametersController(IProjectParametersService projectParametersService)
        {
            _projectParametersService = projectParametersService;
        }

        // GET: api/<ProjectParametersController>
        [HttpGet("GetAllProjectParameters")]
        public async Task<IActionResult> GetAllParameters()
        {
            var ProjectParameters = await _projectParametersService.GetAllParameters();
            return Ok(ProjectParameters);
        }

        // GET api/<ProjectParametersController>/5
        [HttpGet("GetByIdProjectParameters")]
        public async Task<IActionResult> GetByIdParameters(int Id)
        {
            var p = await _projectParametersService.GetByIdParameters(Id);
            if (p == null)
            {
                return NotFound();
            }

            return Ok(p);
        }

        // POST api/<ProjectParametersController>
        [HttpPost("CreateProjectParameters")]
        public IActionResult CreateParameters([FromBody] ProjectParameters ProjectParameters)
        {
            _projectParametersService.CreateParameters(ProjectParameters);
            return Ok(ProjectParameters);
        }

        // PUT api/<ProjectParametersController>/5
        [HttpPut("UpdateProjectParameters")]
        public IActionResult UpdateParameters([FromBody] ProjectParameters ProjectParameters)
        {
            _projectParametersService.UpdateParameters(ProjectParameters);
            return Ok(ProjectParameters);
        }

        // DELETE api/<ProjectParametersController>/5
        [HttpDelete("DeleteProjectParameters")]
        public IActionResult DeleteParameters([FromBody] ProjectParameters ProjectParameters)
        {
            _projectParametersService.DeleteParameters(ProjectParameters);
            return Ok("Silindi");
        }

        // CALCULATE api/<ProjectParametersController>/5
        [HttpPost("Calculate")]
        public IActionResult Calculate([FromBody] int projectId)
        {
            _projectParametersService.Calculate(projectId);
            return Ok("Hesaplamalar doğru şekilde yapıldı");
        }
    }
}
