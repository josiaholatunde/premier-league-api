using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Fixtures.API.Data;
using Fixtures.API.DTOS;
using Fixtures.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fixtures.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IPremierLeagueRepository _repository;
        private readonly IMapper _mapper;

        public UsersController(IPremierLeagueRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name="GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repository.GetUser(id);
            if (user == null)
                return NotFound();
            var userToReturn = _mapper.Map<UserToReturnDto>(user);
            return Ok(userToReturn);
        }
    }
}