using Microsoft.AspNetCore.Mvc;
using Smurfs.Business.Abstract;
using Smurfs.Entities.Conrete;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Smurfs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallStatusController : ControllerBase
    {
        private ICallStatusService _callstatusService;
        public CallStatusController(ICallStatusService CallStatus)
        {
            _callstatusService = CallStatus;
        }
        // GET: api/<CallStatusController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var CallStatus = await _callstatusService.GetAll();
            return Ok(CallStatus);
        }

        // GET api/<CallStatusController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var p = await _callstatusService.GetById(Id);
            if (p == null)
            {
                return NotFound();
            }

            return Ok(p);
        }

        // POST api/<CallStatusController>
        [HttpPost]
        public IActionResult Create([FromBody] CallStatus CallStatus)
        {
            _callstatusService.Create(CallStatus);
            return Ok(CallStatus);
        }

        // PUT api/<CallStatusController>/5
        [HttpPut]
        public IActionResult Update([FromBody] CallStatus CallStatus)
        {
            _callstatusService.Update(CallStatus);
            return Ok(CallStatus);
        }

        // DELETE api/<CallStatusController>/5
        [HttpDelete]
        public IActionResult Delete([FromBody] CallStatus CallStatus)
        {
            _callstatusService.Delete(CallStatus);
            return Ok("Silindi");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<CallStatus>> DeleteCallStatus(int id)
        {
            try
            {
                var employeeToDelete = await _callstatusService.GetById(id);

                if (employeeToDelete == null)
                {
                    return NotFound($"CallStatus with Id = {id} not found");
                }

                return await _callstatusService.DeleteCallStatus(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
