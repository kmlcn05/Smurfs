using Microsoft.AspNetCore.Mvc;
using Smurfs.Business.Abstract;
using Smurfs.Entities.Conrete;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Smurfs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService DepartmentService)
        {
            _departmentService = DepartmentService;
        }
        // GET: api/<DepartmentController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var DepartmentService = await _departmentService.GetAll();
            return Ok(DepartmentService);
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var p = await _departmentService.GetById(Id);
            if (p == null)
            {
                return NotFound();
            }

            return Ok(p);
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public IActionResult Create([FromBody] Department Department)
        {
            _departmentService.Create(Department);
            return Ok(Department);
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Department Department)
        {
            _departmentService.Update(Department);
            return Ok(Department);
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody] Department Department)
        {
            _departmentService.Delete(Department);
            return Ok("Silindi");
        }
    }
}
