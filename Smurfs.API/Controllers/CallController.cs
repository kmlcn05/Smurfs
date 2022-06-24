using Microsoft.AspNetCore.Mvc;
using Smurfs.Business.Abstract;
using Smurfs.Entities.Conrete;
using Smurfs.Entity.Concrete;

namespace Smurfs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CallController : ControllerBase
    {
        private ICallService _callService;

        public CallController(ICallService callService)
        {
            _callService = callService;
        }

        // GET: api/<CallController>
        [HttpGet("GetAllCall")]
        public async Task<IActionResult> GetAll()
        {
            var Call = await _callService.GetAll();
            return Ok(Call);
        }
       

        // GET api/<CallController>/5
        [HttpGet("GetByIdCall")]
        public async Task<IActionResult> GetById(int Id)
        {
            var p = await _callService.GetById(Id);
            if (p == null)
            {
                return NotFound();
            }

            return Ok(p);
        }
        

        // POST api/<CallController>
        [HttpPost("CreateCall")]
        public IActionResult Create([FromBody] Call Call)
        {
            _callService.Create(Call);
            return Ok(Call);
        }
       

        // PUT api/<CallController>/5
        [HttpPut("UpdateCall")]
        public IActionResult Update([FromBody] Call Call)
        {
            _callService.Update(Call);
            return Ok(Call);
        }

     

        // DELETE api/<CallController>/5
        [HttpDelete("DeleteCall")]
        public IActionResult Delete([FromBody] Call Call)
        {
            _callService.Delete(Call);
            return Ok("Silindi");
        }
        
    }
}

