using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smurfs.Business.Abstract;
using Smurfs.Entity.DTO_s;
using System.Net;
using System.Net.Mail;

namespace Smurfs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private IEmailService _mailService;

        public EmailController(IEmailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserDto User)
        {
            try
            {
                _mailService.SendMail(User);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
           
        }
        [HttpPost("Notification")]
        public IActionResult Notification([FromBody] string icerik)
        {
            try
            {
                _mailService.Notification(icerik);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }

}
