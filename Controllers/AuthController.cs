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
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repository;
        private readonly IMapper _mapper;

        public AuthController(IAuthRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET api/values
        [HttpPost("login")]
        public Task<IActionResult> LoginUser(UserForLoginDto userForLoginDto)
        {
            
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(UserForRegistrationDto userForRegistrationDto)
        {
            if (String.IsNullOrEmpty(userForRegistrationDto.Username.Trim()) || String.IsNullOrEmpty(userForRegistrationDto.Password.Trim()))
                return BadRequest("Username or Password is Invalid");
            userForRegistrationDto.Username = userForRegistrationDto.Username.ToLower();

            if (await _repository.UserExists(userForRegistrationDto.Username))
                return BadRequest("Username exists");
            var userToCreate = _mapper.Map<User>(userForRegistrationDto);
            var createdUser = _repository.RegisterUser(userToCreate, userForRegistrationDto.Password);
            var userToReturn = _mapper.Map<UserToReturnDto>(createdUser);
            return CreatedAtRoute("GetUser", new { controller="Users", id = userToReturn.Id}, userToReturn);
        }

    }
}