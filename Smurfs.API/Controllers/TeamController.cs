﻿using Microsoft.AspNetCore.Mvc;
using Smurfs.Business.Abstract;
using Smurfs.Entities.Conrete;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Smurfs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private ITeamService _teamService;
        public TeamController(ITeamService TeamService)
        {
            _teamService = TeamService;
        }
        // GET: api/<TeamController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var TeamService = await _teamService.GetAll();
            return Ok(TeamService);
        }

        // GET api/<TeamController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var p = await _teamService.GetById(Id);
            if (p == null)
            {
                return NotFound();
            }

            return Ok(p);
        }

        // POST api/<TeamController>
        [HttpPost]
        public IActionResult Create([FromBody] Team Teams)
        {
            _teamService.Create(Teams);
            return Ok(Teams);
        }

        // PUT api/<TeamController>/5
        [HttpPut]
        public IActionResult Update([FromBody] Team Teams)
        {
            _teamService.Update(Teams);
            return Ok(Teams);
        }

        // DELETE api/<TeamController>/5
        [HttpDelete]
        public IActionResult Delete([FromBody] Team Teams)
        {
            _teamService.Delete(Teams);
            return Ok("Silindi");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Team>> DeleteTeam(int id)
        {
            try
            {
                var employeeToDelete = await _teamService.GetById(id);

                if (employeeToDelete == null)
                {
                    return NotFound($"Team with Id = {id} not found");
                }

                return await _teamService.DeleteTeam(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
