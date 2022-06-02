using FilmStock.Models.Entities;
using FilmStock.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace FilmStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;
        private readonly IFilmRepository _filmRepository;
        public CollectionController(IUserRepository userRepository, IConfiguration config, IFilmRepository filmRepository)
        {
            _userRepository = userRepository;
            _config = config;
            _filmRepository = filmRepository;
        }

        [Authorize]
        [HttpGet]
        [Route("{id:long}")]
        public async Task<List<Movie>> GetUserCollection(long id)
        {
            return await _userRepository.GetCollection(id);
        }

        [Authorize]
        [HttpPost]
        [Route("add/{Id:long}")]
        public async Task AddToUserCollection(long Id)
        {
            string name = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).ToString();
            string[] list = name.Split(" ");
            name = list[1];
            await _userRepository.AddToCollection(name, Id);
        }
    }
}
