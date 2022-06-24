using Microsoft.AspNetCore.Mvc;
using Smurfs.Business.Abstract;
using Smurfs.Entities.Conrete;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Smurfs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        
        private IStatusService _statusService;
        public StatusController(IStatusService StatusService)
        {
            _statusService = StatusService;
        }
        // GET: api/<StatusController>/5
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var StatusService = await _statusService.GetAll();
            return Ok(StatusService);
        }

        // GET api/<StatusController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var p = await _statusService.GetById(Id);
            if (p == null)
            {
                return NotFound();
            }

            return Ok(p);
        }

        // POST api/<StatusController>/5
        [HttpPost]
        public IActionResult Create([FromBody] Status Status)
        {
            _statusService.Create(Status);
            return Ok(Status);
        }

        // PUT api/<StatusController>/5
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Status Status)
        {
            _statusService.Update(Status);
            return Ok(Status);
        }

        // DELETE api/<StatusController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody] Status Status)
        {
            _statusService.Delete(Status);
            return Ok("Silindi");
        }
    }
}
