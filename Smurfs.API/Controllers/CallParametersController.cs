using Microsoft.AspNetCore.Mvc;
using Smurfs.Business.Abstract;
using Smurfs.Entities.Conrete;
using Smurfs.Entity.Concrete;
using Smurfs.Entity.DTO_s;

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
        public IActionResult CreateParameters([FromBody] CallParametersDto CallParameters)
        {
            _callParametersService.CreateParameters(CallParameters);
            return Ok(CallParameters);
        }

      

        // PUT api/<CallParametersController>/5
        [HttpPut("UpdateCallParameters")]
        public IActionResult UpdateParameters([FromBody] CallParametersDto CallParameters)
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

        // CALCULATE api/<CallController>/5
        [HttpPost("CalculateCall")]
        public IActionResult Calculate([FromBody] int projectId)
        {
            _callParametersService.Calculate(projectId);
            return Ok("Hesaplamalar doğru şekilde yapıldı");
        }

        [HttpGet("GetCallParameters")]
        public IActionResult GetCallParameters()
        {
            var CallParameters = _callParametersService.CallParametersDetails();
            return Ok(CallParameters);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CallParameters>> DeleteCallParameters(int id)
        {
            try
            {
                var employeeToDelete = await _callParametersService.GetByIdParameters(id);

                if (employeeToDelete == null)
                {
                    return NotFound($"ITSM with Id = {id} not found");
                }

                return await _callParametersService.DeleteCallParameters(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

    }
}
