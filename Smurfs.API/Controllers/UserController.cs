using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smurfs.Business.Abstract;
using Smurfs.Entities.Conrete;
using Smurfs.Entity.DTO_s;

namespace Smurfs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<BankController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var User = await _userService.GetAll();
            return Ok(User);
        }

        // GET api/<BankController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var p = await _userService.GetById(Id);
            if (p == null)
            {
                return NotFound();
            }

            return Ok(p);
        }

        // POST api/<BankController>
        [HttpPost]
        public IActionResult Create([FromBody] UserDto User)
        {
            _userService.Create(User);
            return Ok(User);
        }

        // PUT api/<BankController>/5
        [HttpPut]
        public IActionResult Update([FromBody] UserDto User)
        {
            _userService.Update(User);
            return Ok(User);
        }

        // DELETE api/<BankController>/5
        [HttpDelete]
        public IActionResult Delete([FromBody] User User)
        {
            _userService.Delete(User);
            return Ok("Silindi");
        }

        [HttpGet("GetUser")]
        public IActionResult GetUser()
        {
            var User = _userService.UserDetails();
            return Ok(User);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            try
            {
                var employeeToDelete = await _userService.GetById(id);

                if (employeeToDelete == null)
                {
                    return NotFound($"ITSM with Id = {id} not found");
                }

                return await _userService.DeleteUser(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}

