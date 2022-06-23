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
        // GET: api/<CallParametersController>
        [HttpGet("GetAllCallParameters")]
        public async Task<IActionResult> GetAllParameters()
        {
            var CallParameters = await _callService.GetAllParameters();
            return Ok(CallParameters);
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
        // GET api/<CallParametersController>/5
        [HttpGet("GetByIdCallParameters")]
        public async Task<IActionResult> GetByIdParameters(int Id)
        {
            var p = await _callService.GetByIdParameters(Id);
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
        // POST api/<CallParametersController>
        [HttpPost("CreateCallParameters")]
        public IActionResult CreateParameters([FromBody] CallParameters CallParameters)
        {
            _callService.CreateParameters(CallParameters);
            return Ok(CallParameters);
        }

        // PUT api/<CallController>/5
        [HttpPut("UpdateCall")]
        public IActionResult Update([FromBody] Call Call)
        {
            _callService.Update(Call);
            return Ok(Call);
        }

        // PUT api/<CallParametersController>/5
        [HttpPut("UpdateCallParameters")]
        public IActionResult UpdateParameters([FromBody] CallParameters CallParameters)
        {
            _callService.UpdateParameters(CallParameters);
            return Ok(CallParameters);
        }

        // DELETE api/<CallController>/5
        [HttpDelete("DeleteCall")]
        public IActionResult Delete([FromBody] Call Call)
        {
            _callService.Delete(Call);
            return Ok("Silindi");
        }
        // DELETE api/<CallParametersController>/5
        [HttpDelete("DeleteCallParameters")]
        public IActionResult DeleteParameters([FromBody] CallParameters CallParameters)
        {
            _callService.DeleteParameters(CallParameters);
            return Ok("Silindi");
        }

        // CALCULATE api/<CallController>/5
        [HttpPost("CalculateCall")]
        public IActionResult Calculate([FromBody] int projectId)
        {
            _callService.Calculate(projectId);
            return Ok("Hesaplamalar doğru şekilde yapıldı");
        }
    }
}

