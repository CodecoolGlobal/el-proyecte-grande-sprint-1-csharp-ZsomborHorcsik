using Microsoft.AspNetCore.Mvc;
using FilmStock.Models;
using FilmStock.Services;

namespace FilmStock.Controllers
{
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly ReviewService _reviewService;

        public ReviewController(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost("/AddReview")]
        public IActionResult AddReview(string MovieId, Guid userId, [FromBody]int? starReview, string? review)
        {
            ReviewModel newReview = new();
            newReview.UserId = userId;
            newReview.ReviewId = Guid.NewGuid();
            newReview.MovieId = MovieId;
            newReview.StarRating = starReview;
            newReview.Review = review;
            newReview.Date = DateTime.Now;
            return Ok("Review sent");
        }

        [HttpPut("/EditReview/{Id}")]
        public IActionResult EditReview(Guid Id, [FromBody]int? starReview, string? reviewcontent)
        {
            ReviewModel review = _reviewService.GetReviewById(Id);
            review.StarRating = starReview;
            review.Review = reviewcontent;
            review.EditDate = DateTime.Now;
            return View();
        }

        [HttpDelete("/DeleteReview/{Id}")]
        //tt0111161
        public IActionResult DeleteReview(Guid Id)
        {
            _reviewService.Delete(Id);
            return Ok("Review removed!");
        }

        [HttpGet("/VoteUpReview/{Id}")]
        public IActionResult VoteUp(Guid id)
        {
            _reviewService.VoteUp(id);
            return Ok("Upvoted!");
        }

        [HttpGet("/VoteDownReview/{Id}")]
        public IActionResult VoteDown(Guid id)
        {
            _reviewService.VoteDown(id);
            return Ok("Upvoted!");
        }
    }
}
