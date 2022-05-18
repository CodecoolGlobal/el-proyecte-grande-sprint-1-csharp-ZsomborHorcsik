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

        [HttpPost("new")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            await _iuserRepository.Add(user);
            return CreatedAtAction("User created", new { user.Id }, user);

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
            return await _iuserRepository.GetUser(id);
        }
    }
}
