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
        public async Task<IActionResult> AddReview([FromBody] Review review, long movieId)
        {
            string username = _session.GetString("User");

            await _reviewRepository.Add(review, username, movieId);
            return CreatedAtAction("Review created", new { review.ReviewId }, review);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateReview([FromBody] Review review)
        {
            string username = _session.GetString("User");

            await _reviewRepository.Update(review);
            return CreatedAtAction("Reveiw updated", new { review.ReviewId }, review);
        }

        [HttpDelete("delete/{id}")]
        public async Task Delete([FromBody] Review review)
        {
            await _reviewRepository.Remove(review.ReviewId);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<Review?> GetById(long id)
        {
            return await _reviewRepository.GetReview(id);
        }

        [HttpGet("getbyuser/{username}")]
        public async Task<List<Review>> GetByUser(string username)
        {
            return await _reviewRepository.GetReviewsByUser(username);
        }

        [HttpGet("getbymovie/{id}")]
        public async Task<List<Review>> GetBymovie(long id)
        {
            return await _reviewRepository.GetReviewsByMovie(id);
        }
    }
}
