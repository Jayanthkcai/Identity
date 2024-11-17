using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly string _secret;

        public AccountController(IConfiguration configuration)
        {
            _secret = configuration.GetValue<string>("Jwt:Secret");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            // Validate the user credentials (this is just a demo, so always successful)
            if (model.Username == "test" && model.Password == "password")
            {
                var token = JwtTokenHelper.GenerateToken(model.Username, _secret);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
