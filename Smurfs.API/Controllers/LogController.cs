using Microsoft.AspNetCore.Mvc;
using Smurfs.Business.Abstract;
using Smurfs.Entities.Conrete;

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
        public IActionResult Create([FromBody] Log Log)
        {
            _logService.Create(Log);
            return Ok(Log);
        }

        // PUT api/<LogController>/5
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Log Log)
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
    }
}
