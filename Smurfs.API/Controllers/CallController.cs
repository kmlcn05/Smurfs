using Microsoft.AspNetCore.Mvc;
using Smurfs.Business.Abstract;
using Smurfs.Entities.Conrete;
using Smurfs.Entity.Concrete;
using Smurfs.Entity.DTO_s;

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
        public IActionResult Create([FromBody] GetCallDto call)
        {
            _callService.Create(call);
            return Ok(call);
        }
       

        // PUT api/<CallController>/5
        [HttpPut("UpdateCall")]
        public IActionResult Update([FromBody] GetCallDto Call)
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

        [HttpGet("GetCall")]
        public IActionResult GetCall()
        {
            var Call = _callService.GetCallDetails();
            return Ok(Call);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Call>> DeleteCall(int id)
        {
            try
            {
                var employeeToDelete = await _callService.GetById(id);

                if (employeeToDelete == null)
                {
                    return NotFound($"ITSM with Id = {id} not found");
                }

                return await _callService.DeleteCall(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

    }
}

