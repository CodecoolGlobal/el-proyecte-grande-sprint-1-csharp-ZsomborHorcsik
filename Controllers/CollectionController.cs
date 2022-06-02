using FilmStock.Models.Entities;
using FilmStock.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;
        public CollectionController(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<List<Movie>> GetUserCollection(long id)
        {
            return await _userRepository.GetCollection(id);
        }

        [HttpPost]
        [Route("add/{Id:long}")]
        public async Task<IActionResult> AddToUserCollection(long Id)
        {
            var authorizedUser = User.Claims;
            return Ok();
            //await _userRepository.AddToCollection(id, movieId);
        }
    }
}
