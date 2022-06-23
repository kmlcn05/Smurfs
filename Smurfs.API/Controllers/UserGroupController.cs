using Microsoft.AspNetCore.Mvc;
using Smurfs.Business.Abstract;
using Smurfs.Entities.Conrete;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Smurfs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupController : ControllerBase
    {
        private IUserGroupService _usergroupservis;

        public UserGroupController(IUserGroupService UserGroupService)
        {
            _usergroupservis = UserGroupService;
        }
        // GET: api/<UserGroupController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var UserGroup = await _usergroupservis.GetAll();
            return Ok(UserGroup);
        }

        // GET api/<UserGroupController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var p = await _usergroupservis.GetById(Id);
            if (p == null)
            {
                return NotFound();
            }

            return Ok(p);
        }

        // POST api/<UserGroupController>
        [HttpPost]
        public IActionResult Create([FromBody] UserGroup UserGroup)
        {
            _usergroupservis.Create(UserGroup);
            return Ok(UserGroup);
        }

        // PUT api/<UserGroupController>/5
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] UserGroup UserGroup)
        {
            _usergroupservis.Update(UserGroup);
            return Ok(UserGroup);
        }

        // DELETE api/<UserGroupController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody] UserGroup UserGroup)
        {
            _usergroupservis.Delete(UserGroup);
            return Ok("Silindi");
        }
    }
}
