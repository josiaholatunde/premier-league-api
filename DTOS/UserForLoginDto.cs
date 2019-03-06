using System;
using System.ComponentModel.DataAnnotations;

namespace Fixtures.API.DTOS
{
    public class UserForLoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}