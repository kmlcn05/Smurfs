using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smurfs.Business.Abstract;

namespace Smurfs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getuser")]
        public IActionResult GetUserById(int id)
        {
            var result = _userService.GetUserById(id);
            return Ok(result);
        }

        [HttpGet("getmail")]
        public IActionResult GetMail(string mail)
        {
            var result = _userService.GetMail(mail);
            return Ok(result);
        }

        [HttpGet("getpassword")]
        public IActionResult GetPassword(string password)
        {
            var result = _userService.GetPassword(password);
            return Ok(result);
        }
    }
}
