using Microsoft.AspNetCore.Mvc;
using Smurfs.Business.Abstract;
using Smurfs.Entities.Conrete;
using Smurfs.Entity.DTO_s;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Smurfs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private ILogService _logService;
        public LogController(ILogService LogService)
        {
            _logService = LogService;
        }
        // GET: api/<LogController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var LogService = await _logService.GetAll();
            return Ok(LogService);
        }

        // GET api/<LogController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var p = await _logService.GetById(Id);
            if (p == null)
            {
                return NotFound();
            }

            return Ok(p);
        }
        // POST api/<LogController>
        [HttpPost]
        public IActionResult Create([FromBody] LogDto Log)
        {
            _logService.Create(Log);
            return Ok(Log);
        }

        // PUT api/<LogController>/5
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] LogDto Log)
        {
            _logService.Update(Log);
            return Ok(Log);
        }

        // DELETE api/<LogController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody] Log Log)
        {
            _logService.Delete(Log);
            return Ok("Silindi");
        }

        [HttpGet("GetLog")]
        public IActionResult GetLog()
        {
            var Log = _logService.LogDetails();
            return Ok(Log);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Log>> DeleteLog(int id)
        {
            try
            {
                var employeeToDelete = await _logService.GetById(id);

                if (employeeToDelete == null)
                {
                    return NotFound($"ITSM with Id = {id} not found");
                }

                return await _logService.DeleteLog(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
