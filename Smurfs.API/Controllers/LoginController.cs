using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smurfs.API.Helpers;
using Smurfs.Business.Abstract;
using Smurfs.DataAccess.Models;

namespace Smurfs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("Login")]
        public IActionResult Login(UserLoginModel user)
        {
            var userToLogin = _loginService.Login(user);
            if(!userToLogin.Success)
            {
                return BadRequest(userToLogin);
            }
            else
            {
                return Ok(userToLogin);
            }
        }

        //Session Kullanımına örnek.

        //[HttpPost("login-user")]
        //public IActionResult LoginUser(string email, string password)
        //{
        //    //Servis çağırımı yapılır başarılı sonuç dönderse aşağıdaki gibi kullanıcı sessiona alınır.

        //    object user = new();

        //    //Sessiona Kullanıcı Ekler.
        //    HttpContext.Session.SetObject("loginUser", user);

        //    //Sessiondaki Kullanıcıyı Getirir.
        //    var loggedUser = HttpContext.Session.GetObject<object>("loginUser");

        //    return Ok();
        //}

        //[HttpGet("getuser")]
        //public IActionResult GetUserById(int id)
        //{
        //    var result = _userService.GetUserById(id);
        //    return Ok(result);
        //}

        //[HttpGet("getmail")]
        //public IActionResult GetMail(string mail)
        //{
        //    var result = _userService.GetMail(mail);
        //    return Ok(result);
        //}

        //[HttpGet("getpassword")]
        //public IActionResult GetPassword(string password)
        //{
        //    var result = _userService.GetPassword(password);
        //    return Ok(result);
        //}
    }
}
