using Microsoft.AspNetCore.Mvc;
using FilmStock.Models.Interfaces;
using FilmStock.Models.Entities;

namespace FilmStock.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _iuserRepository;

        public UserController(IUserRepository iuserRepository)
        {
            _iuserRepository = iuserRepository;
        }

        //how to retirieve data from FromForm
        [HttpPost("register")]
        public async Task<IActionResult> AddUser([FromForm]User user)
        {
            user.Level = Models.Enums.UserLevel.user;
            await _iuserRepository.Add(user);
            return CreatedAtAction("User created", new { user.Id }, user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginModel user)
        {
            User? userByName = await _iuserRepository.GetUserByUsername(user.UserName);
            if (userByName == null)
            {
                return NotFound();
            }
            if (user.Password == userByName.Password)
            {
                return Ok(userByName);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPut("edit/{Id}")]
        public void EditUser(long Id, [FromBody] User user)
        {
            user.Id = Id;
            _iuserRepository.Update(user);
        }

        [HttpDelete("delete/{Id}")]
        public async Task DeleteUser(long Id)
        {
            await _iuserRepository.Remove(Id);
        }

        [HttpGet("{id:long}")]
        public async Task<User?> GetUserById(long id)
        {
            return await _iuserRepository.GetUserById(id);
        }
    }
}
