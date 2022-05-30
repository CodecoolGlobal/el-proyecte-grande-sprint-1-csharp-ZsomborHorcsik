using Microsoft.AspNetCore.Mvc;
using FilmStock.Models.Interfaces;
using FilmStock.Models.Entities;
using Microsoft.AspNetCore.Http;
using System.Linq;
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
        private readonly ISession _session;
        private readonly IConfiguration _config;

        public UserController(IUserRepository iuserRepository, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _userRepository = iuserRepository;
            _session = httpContextAccessor.HttpContext.Session;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> AddUser([FromForm]User user)
        {
            user.Level = Models.Enums.UserLevel.user;
            user.Collection = new();
            await _userRepository.Add(user);
            return Redirect("http://localhost:3000/");
        }

        [HttpPost]
        [Route("LoginUser")]
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
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, currentUser.UserName),
                new Claim(ClaimTypes.Email, currentUser.Email),
                new Claim(ClaimTypes.Surname, currentUser.LastName),
                new Claim(ClaimTypes.GivenName, currentUser.FirstName)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<User> Authenticate(LoginModel user)
        {
            if(await _userRepository.ValidateUser(user))
            {
                return await _userRepository.GetUserByUsername(user.UserName);
            }
            return null;

        }

        [HttpPut("edit/{Id}")]
        public void EditUser(long Id, [FromBody] User user)
        {
            user.Id = Id;
            _userRepository.Update(user);
        }

        [HttpDelete("delete/{Id}")]
        public async Task DeleteUser(long Id)
        {
            await _userRepository.Remove(Id);
        }

        [HttpGet("{id:long}")]
        public async Task<User?> GetUserById(long id)
        {
            return await _userRepository.GetUserById(id);
        }

        [HttpGet("collection/{id}")]
        public async Task<List<Movie>> GetUserCollection(long id)
        {
            return await _userRepository.GetCollection(id);
        }

        [HttpGet("collection/{id}")]
        public async Task AddToUserCollection(long id, long movieId)
        {
            await _userRepository.AddToCollection(id, movieId);
        }
    }
}
