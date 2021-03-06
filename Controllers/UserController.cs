using Microsoft.AspNetCore.Mvc;
using FilmStock.Models.Interfaces;
using FilmStock.Models.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace FilmStock.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public UserController(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser([FromBody]User user)
        {
            var dbUserInfo = await _userRepository.GetUserByUsername(user.UserName);
            if (dbUserInfo == null)
            {
                user.Level = Models.Enums.UserLevel.user;
                user.UserCollection = new();
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                await _userRepository.Add(user);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginModel user)
        {
            var currentUser = await Authenticate(user);
            if (currentUser == null)
            {
                return NotFound("User not found");
            }
            var token = Generate(currentUser);
            return Ok(token);
        }

        private string Generate(User currentUser)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Authentication:SecretForKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, currentUser.UserName),
                new Claim(ClaimTypes.Email, currentUser.Email),
                new Claim(ClaimTypes.Surname, currentUser.LastName),
                new Claim(ClaimTypes.GivenName, currentUser.FirstName)
            };

            var token = new JwtSecurityToken(_config["Authentication:Issuer"],
                _config["Authentication:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<User> Authenticate(LoginModel user)
        {
            var dbUserInfo = await _userRepository.GetUserByUsername(user.UserName);
            var isPwMatch = BCrypt.Net.BCrypt.Verify(user.Password, dbUserInfo.Password);
            if (dbUserInfo != null && isPwMatch)
            {
                return dbUserInfo;
            }
            return null;

        }
    }
}
