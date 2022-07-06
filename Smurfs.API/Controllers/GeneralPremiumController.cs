using Microsoft.AspNetCore.Mvc;
using Smurfs.Business.Abstract;
using Smurfs.Entity.Concrete;

namespace Smurfs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralPremiumController : ControllerBase
    {

        private IGeneralPremiumService _generalpremiumService;
        public GeneralPremiumController(IGeneralPremiumService GeneralPremiumService)
        {
            _generalpremiumService = GeneralPremiumService;
        }
        // GET: api/<PremiumController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var GeneralPremiumService = await _generalpremiumService.GetAll();
            return Ok(GeneralPremiumService);
        }

        // GET api/<PremiumController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var gp = await _generalpremiumService.GetById(Id);
            if (gp == null)
            {
                return NotFound();
            }

            return Ok(gp);
        }

        // POST api/<PremiumController>
        [HttpPost]
        public IActionResult Create(int Id, DateTime premiumDate, string name, string surname, string projectAmount = "0", string callAmount = "0")
        {
            _generalpremiumService.Create(Id, premiumDate, name, surname, projectAmount, callAmount);
            return Ok("Eklendi");
        }

        // PUT api/<PremiumController>/5
        [HttpPut]
        public IActionResult Update(int Id, DateTime premiumDate, string name, string surname, string projectAmount, string callAmount)
        {
            _generalpremiumService.Update(Id, premiumDate, name, surname, projectAmount, callAmount);
            return Ok("Güncellendi");
        }

        // DELETE api/<PremiumController>/5
        [HttpDelete]
        public IActionResult Delete([FromBody] GeneralPremium Premium)
        {
            _generalpremiumService.Delete(Premium);
            return Ok("Silindi");
        }

        [HttpGet("GetPremium")]
        public IActionResult GetPremium()
        {
            var GeneralPremium = _generalpremiumService.GeneralPremiumDetails();
            return Ok(GeneralPremium);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GeneralPremium>> DeleteGeneralPremium(int id)
        {
            try
            {
                var employeeToDelete = await _generalpremiumService.GetById(id);

                if (employeeToDelete == null)
                {
                    return NotFound($"ITSM with Id = {id} not found");
                }

                return await _generalpremiumService.DeleteGeneralPremium(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
