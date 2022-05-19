using Microsoft.AspNetCore.Mvc;
using FilmStock.Models.Interfaces;
using FilmStock.Models.Entities;

namespace FilmStock.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly ISession _session;

        public ReviewController(IReviewRepository reviewRepository, IHttpContextAccessor httpContextAccessor)
        {
            _reviewRepository = reviewRepository;
            _session = httpContextAccessor.HttpContext.Session;
        }

        [HttpPost("new/{movie-id}")]
        public async Task<IActionResult> AddMovie([FromBody] Review review, long movieId)
        {
            string username = _session.GetString("User");

            await _reviewRepository.Add(review, username, movieId);
            return CreatedAtAction("Movie created", new { review.ReviewId }, review);
        }
    }
}
