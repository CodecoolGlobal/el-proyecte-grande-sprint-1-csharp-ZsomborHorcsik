using Microsoft.AspNetCore.Mvc;
using FilmStock.Models.Interfaces;
using FilmStock.Models.Entities;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace FilmStock.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _iuserRepository;
        private readonly ISession _session;

        public UserController(IUserRepository iuserRepository, IHttpContextAccessor httpContextAccessor)
        {
            _iuserRepository = iuserRepository;
            _session = httpContextAccessor.HttpContext.Session;
        }

        //how to retirieve data from FromForm
        [HttpPost("register")]
        public async Task<IActionResult> AddUser([FromForm]User user)
        {
            user.Level = Models.Enums.UserLevel.user;
            user.Collection = new();
            await _iuserRepository.Add(user);
            return Redirect("http://localhost:3000/");
        }

        [HttpPost]
        [Route("LoginUser")]
        public async Task<IActionResult> LoginUser([FromForm] LoginModel user)
        {
            if (await _iuserRepository.ValidateUser(user))
            {
                this._session.SetString("User", user.UserName);
                Console.WriteLine(user.UserName);
                return Redirect("http://localhost:3000/");
            }
            return Redirect("http://localhost:3000/login");
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

        [HttpGet("collection/{id}")]
        public async Task<List<Movie>> GetUserCollection(long id)
        {
            return await _iuserRepository.GetCollection(id);
        }

        [HttpGet("collection/{id}")]
        public async Task AddToUserCollection(long id, long movieId)
        {
            await _iuserRepository.AddToCollection(id, movieId);
        }
    }
}
