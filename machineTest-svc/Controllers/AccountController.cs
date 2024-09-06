using machineTest_svc.Authentication.Token;
using machineTest_svc.Data;
using machineTest_svc.Helpers;
using machineTest_svc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace machineTest_svc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly string _userFilePath = "Data/users.json";
        private readonly IJwtTokenGeneration _jwtTokenGeneration;

        public AccountController(IJwtTokenGeneration jwtTokenGeneration)
        {
            _jwtTokenGeneration=jwtTokenGeneration;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest newUser)
        {
            var users = JsonFileHandler.ReadJsonFile<User>(_userFilePath);

            if (users.Any(u => u.Email == newUser.Email))
                return BadRequest("User Email Id already exists.");
            User user=new User();

            user.Id = Guid.NewGuid().ToString();
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newUser.Password);
            user.Email = newUser.Email;
            user.Name = newUser.Name;

            users.Add(user);
            JsonFileHandler.WriteJsonFile(_userFilePath, users);

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            var users = JsonFileHandler.ReadJsonFile<User>(_userFilePath);
            var user = users.FirstOrDefault(u => u.Email == loginRequest.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.PasswordHash))
                return Unauthorized("Invalid email or password.");

            var token = _jwtTokenGeneration.GenerateJwtToken(user);
            return Ok(new { Token = token });
        }

    }
}
