using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smurfs.Business.Abstract;
using Smurfs.Entities.Conrete;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Smurfs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private IBankService _bankService;

        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }

        // GET: api/<BankController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Bank = await _bankService.GetAll();
            return Ok(Bank);
        }

        // GET api/<BankController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var p = await _bankService.GetById(Id);
            if (p == null)
            {
                return NotFound();
            }

            return Ok(p);
        }

        // POST api/<BankController>
        [HttpPost]
        public IActionResult Create([FromBody] Bank Bank)
        {
            _bankService.Create(Bank);
            return Ok(Bank);
        }

        // PUT api/<BankController>/5
        [HttpPut]
        public IActionResult Update([FromBody] Bank Bank)
        {
            _bankService.Update(Bank);
            return Ok(Bank);
        }

        // DELETE api/<BankController>/5
        [HttpDelete]
        public IActionResult Delete([FromBody] Bank Bank)
        {
            _bankService.Delete(Bank);
            return Ok("Silindi");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Bank>> DeleteBank(int id)
        {
            try
            {
                var employeeToDelete = await _bankService.GetById(id);

                if (employeeToDelete == null)
                {
                    return NotFound($"Bank with Id = {id} not found");
                }

                return await _bankService.DeleteBank(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
