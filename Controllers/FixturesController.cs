using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Fixtures.API.Data;
using Fixtures.API.DTOS;
using Fixtures.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fixtures.API.Controllers
{
    [Authorize(Roles= nameof(UserRole.Admin))]
    [Route("api/teams/{teamId}/fixtures")]
    [ApiController]
    public class FixturesController : ControllerBase
    {
        private readonly IPremierLeagueRepository _repository;
        private readonly IMapper _mapper;

        public FixturesController(IPremierLeagueRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetFixtures(int teamId)
        {
            var fixtures = await _repository.GetFixturesForTeam(teamId);
            return Ok(fixtures);
        }

        [HttpGet("{fixtureId}", Name="GetFeature")]
        public async Task<IActionResult> GetFixture(int teamId, int fixtureId)
        {
            var teamFromRepo = await _repository.GetTeam(teamId);
            if (teamFromRepo == null)
                return BadRequest("Team does not exist");
            var fixtureFromRepo = await _repository.GetFixture(fixtureId);
            if (fixtureFromRepo == null)
                return BadRequest("Fixture does not exist");
            var fixtureToReturn = _mapper.Map<FixtureToReturn>(fixtureFromRepo);
            return Ok(fixtureToReturn);
        }


        [HttpPost]
        public async Task<IActionResult> CreateTeamFixture(int teamId, [FromBody] FixtureToCreate fixtureToCreateDto)
        {
            fixtureToCreateDto.TeamId = teamId;
            var teamFromRepo = await _repository.GetTeam(teamId);
            if (teamFromRepo == null)
                return BadRequest("Team does not exist");
            var fixtureToCreate = _mapper.Map<Fixture>(fixtureToCreateDto);
            _repository.Add<Fixture>(fixtureToCreate);
            if (await _repository.SaveAllChangesAsync())
            {
                var fixtureToReturn = _mapper.Map<TeamToReturnDto>(fixtureToCreate);
                return CreatedAtRoute("GetFixture", new { id = fixtureToReturn.Id}, fixtureToReturn);
            }
            return BadRequest("An Error occurred while creating the fixture");
        }

        [HttpPut("{fixtureId}")]
        public async Task<IActionResult> EditFixture(int teamId, int fixtureId, [FromBody] FixtureToCreate fixtureToEditDto)
        {
            var teamFromRepo = await _repository.GetTeam(teamId);
            if (teamFromRepo == null)
                return BadRequest("Team does not exist");
            var fixtureFromRepo = await _repository.GetFixture(fixtureId);
            if (fixtureFromRepo == null)
                return BadRequest($"Fixture with id {fixtureId} does not exist");
            
            var fixtureToUpdate = _mapper.Map<FixtureToCreate, Fixture>(fixtureToEditDto, fixtureFromRepo);
            _repository.Update<Fixture>(fixtureToUpdate);
            if (await _repository.SaveAllChangesAsync())
            {
                var fixtureToReturn = _mapper.Map<FixtureToReturn>(fixtureToUpdate);
                return NoContent();
            }
            throw new Exception($"Error Editing fixture with id {teamId}");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFixture(int teamId, int id)
        {
            var teamFromRepo = await _repository.GetTeam(id);
            if (teamFromRepo == null)
                return BadRequest("Team does not exist");
             var fixtureFromRepo = await _repository.GetFixture(id);
            if (fixtureFromRepo == null)
                return BadRequest($"Fixture with id {id} does not exist");
            _repository.Delete<Fixture>(fixtureFromRepo);
            if (await _repository.SaveAllChangesAsync())
            {
                return Ok();
            }
            return BadRequest($"An Error occurred while deleting fixture with id {id}");
        }
    }
}