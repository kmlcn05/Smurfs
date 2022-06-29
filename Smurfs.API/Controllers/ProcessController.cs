using Microsoft.AspNetCore.Mvc;
using Smurfs.Business.Abstract;
using Smurfs.Entities.Conrete;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Smurfs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private IProcessService _processService;
        public ProcessController(IProcessService ProcessService)
        {
            _processService = ProcessService;
        }
        // GET: api/<ProcessController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ProcessService = await _processService.GetAll();
            return Ok(ProcessService);
        }

        // GET api/<ProcessController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var p = await _processService.GetById(Id);
            if (p == null)
            {
                return NotFound();
            }

            return Ok(p);
        }

        // POST api/<ProcessController>
        [HttpPost]
        public IActionResult Create([FromBody] Process Process)
        {
            _processService.Create(Process);
            return Ok(Process);
        }

        // PUT api/<ProcessController>/5
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Process Process)
        {
            _processService.Update(Process);
            return Ok(Process);
        }

        // DELETE api/<ProcessController>/5
        [HttpDelete]
        public IActionResult Delete([FromBody] Process Process)
        {
            _processService.Delete(Process);
            return Ok("Silindi");
        }
    }
}
