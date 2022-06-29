using Microsoft.AspNetCore.Mvc;
using Smurfs.Business.Abstract;
using Smurfs.Entities.Conrete;
using Smurfs.Entity.DTO_s;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Smurfs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremiumController : ControllerBase
    {
        private IPremiumService _premiumService;
        public PremiumController(IPremiumService PremiumService)
        {
            _premiumService = PremiumService;
        }
        // GET: api/<PremiumController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var PremiumService = await _premiumService.GetAll();
            return Ok(PremiumService);
        }

        // GET api/<PremiumController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var p = await _premiumService.GetById(Id);
            if (p == null)
            {
                return NotFound();
            }

            return Ok(p);
        }

        // POST api/<PremiumController>
        [HttpPost]
        public IActionResult Create([FromBody] PremiumDto Premium)
        {
            _premiumService.Create(Premium);
            return Ok(Premium);
        }

        // PUT api/<PremiumController>/5
        [HttpPut]
        public IActionResult Update([FromBody] PremiumDto Premium)
        {
            _premiumService.Update(Premium);
            return Ok(Premium);
        }

        // DELETE api/<PremiumController>/5
        [HttpDelete]
        public IActionResult Delete([FromBody] Premium Premium)
        {
            _premiumService.Delete(Premium);
            return Ok("Silindi");
        }

        [HttpGet("GetPremium")]
        public IActionResult GetPremium()
        {
            var Premium = _premiumService.PremiumDetails();
            return Ok(Premium);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Premium>> DeletePremium(int id)
        {
            try
            {
                var employeeToDelete = await _premiumService.GetById(id);

                if (employeeToDelete == null)
                {
                    return NotFound($"ITSM with Id = {id} not found");
                }

                return await _premiumService.DeletePremium(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
