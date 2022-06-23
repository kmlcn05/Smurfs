using Microsoft.AspNetCore.Mvc;
using Smurfs.Business.Abstract;
using Smurfs.Entities.Conrete;
using Smurfs.Entity.Concrete;

namespace Smurfs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CallParametersController : ControllerBase
    {
        private ICallParametersService _callParametersService;

        public CallParametersController(ICallParametersService callParametersService)
        {
            _callParametersService = callParametersService;
        }

      
        // GET: api/<CallParametersController>
        [HttpGet("GetAllCallParameters")]
        public async Task<IActionResult> GetAllParameters()
        {
            var CallParameters = await _callParametersService.GetAllParameters();
            return Ok(CallParameters);
        }

      
        // GET api/<CallParametersController>/5
        [HttpGet("GetByIdCallParameters")]
        public async Task<IActionResult> GetByIdParameters(int Id)
        {
            var p = await _callParametersService.GetByIdParameters(Id);
            if (p == null)
            {
                return NotFound();
            }

            return Ok(p);
        }

       
        // POST api/<CallParametersController>
        [HttpPost("CreateCallParameters")]
        public IActionResult CreateParameters([FromBody] CallParameters CallParameters)
        {
            _callParametersService.CreateParameters(CallParameters);
            return Ok(CallParameters);
        }

      

        // PUT api/<CallParametersController>/5
        [HttpPut("UpdateCallParameters")]
        public IActionResult UpdateParameters([FromBody] CallParameters CallParameters)
        {
            _callParametersService.UpdateParameters(CallParameters);
            return Ok(CallParameters);
        }

        
        // DELETE api/<CallParametersController>/5
        [HttpDelete("DeleteCallParameters")]
        public IActionResult DeleteParameters([FromBody] CallParameters CallParameters)
        {
            _callParametersService.DeleteParameters(CallParameters);
            return Ok("Silindi");
        }

       
    }
}
