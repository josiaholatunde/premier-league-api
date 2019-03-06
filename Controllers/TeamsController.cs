using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Fixtures.API.Data;
using Fixtures.API.DTOS;
using Fixtures.API.Helpers;
using Fixtures.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fixtures.API.Controllers
{
    [Authorize(Roles= nameof(UserRole.Admin))]
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IPremierLeagueRepository _repository;
        private readonly IMapper _mapper;

        public TeamsController(IPremierLeagueRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET api/values
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
          var teams = await _repository.GetTeams();
          return Ok(teams);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeam(int id)
        {
            var team = await _repository.GetTeam(id);
            if (team == null)
                return BadRequest("Team does not exist");
            return Ok(team);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> CreateTeam([FromBody] TeamToCreateDto teamToCreateDto)
        {
            if (await _repository.TeamExists(teamToCreateDto.Name))
                return BadRequest("Team name exists");
            var teamToCreate = _mapper.Map<Team>(teamToCreateDto);
            _repository.Add<Team>(teamToCreate);
            if (await _repository.SaveAllChangesAsync())
            {
                var teamToReturn = _mapper.Map<TeamToReturnDto>(teamToCreate);
                return CreatedAtRoute("GetTeam", new { id = teamToReturn.Id}, teamToReturn);
            }
            return BadRequest("An Error occurred while creating Team");

        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditTeam(int id, [FromBody] TeamToCreateDto teamToEditDto)
        {
            var teamFromRepo = await _repository.GetTeam(id);
            if (teamFromRepo == null)
                return BadRequest("Team does not exist");
            var teamToUpdate = _mapper.Map<TeamToCreateDto, Team>(teamToEditDto, teamFromRepo);
            _repository.Update<Team>(teamToUpdate);
            if (await _repository.SaveAllChangesAsync())
            {
                var teamToReturn = _mapper.Map<TeamToReturnDto>(teamToUpdate);
                return NoContent();
            }
            throw new Exception($"Error Editing team with id {id}");
        }

         [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var teamFromRepo = await _repository.GetTeam(id);
            if (teamFromRepo == null)
                return BadRequest("Team does not exist");
            _repository.Delete<Team>(teamFromRepo);
            if (await _repository.SaveAllChangesAsync())
            {
                return Ok();
            }
            return BadRequest($"An Error occurred while deleting team with id {id}");
        }
        
        [AllowAnonymous]
        [HttpGet("fixtures")]
        public async Task<IActionResult> GetAllFixtures([FromQuery] UserParams userParams)
        {
            var fixtures = await _repository.GetFixtures(userParams);
            return Ok(fixtures);
        }
    }
}
