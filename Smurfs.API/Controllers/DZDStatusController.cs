using Microsoft.AspNetCore.Mvc;
using Smurfs.Business.Abstract;
using Smurfs.Entities.Conrete;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Smurfs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DZDStatusController : ControllerBase
    {
        private IDZDStatusService _dzdstatusService;
        public DZDStatusController(IDZDStatusService DZDStatusService)
        {
            _dzdstatusService = DZDStatusService;
        }
        // GET: api/<DZDStatusController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var TeamService = await _dzdstatusService.GetAll();
            return Ok(TeamService);
        }

        // GET api/<DZDStatusController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var p = await _dzdstatusService.GetById(Id);
            if (p == null)
            {
                return NotFound();
            }

            return Ok(p);
        }

        // POST api/<DZDStatusController>
        [HttpPost]
        public IActionResult Create([FromBody] DZDStatus DZDStatus)
        {
            _dzdstatusService.Create(DZDStatus);
            return Ok(DZDStatus);
        }

        // PUT api/<DZDStatusController>/5
        [HttpPut]
        public IActionResult Update([FromBody] DZDStatus DZDStatus)
        {
            _dzdstatusService.Update(DZDStatus);
            return Ok(DZDStatus);
        }

        // DELETE api/<DZDStatusController>/5
        [HttpDelete]
        public IActionResult Delete([FromBody] DZDStatus DZDStatus)
        {
            _dzdstatusService.Delete(DZDStatus);
            return Ok("Silindi");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DZDStatus>> DeleteDZDStatus(int id)
        {
            try
            {
                var employeeToDelete = await _dzdstatusService.GetById(id);

                if (employeeToDelete == null)
                {
                    return NotFound($"DZDStatus with Id = {id} not found");
                }

                return await _dzdstatusService.DeleteDZDStatus(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
