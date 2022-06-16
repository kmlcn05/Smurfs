using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI
{
    [Route("api/[controller]")]
    [ApiController]
    public class AjaxAPIController : ControllerBase
    {
        [Route("AjaxMethod")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public LoginModel AjaxMethod (LoginModel person)
        {
            person.DateTime = DateTime.Now.ToString();
            return person;
        }
    }
}
