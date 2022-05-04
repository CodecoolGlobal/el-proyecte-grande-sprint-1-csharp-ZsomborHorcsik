using Microsoft.AspNetCore.Http;
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


        // POST: ReviewController/Create
        [HttpPost]

        public IActionResult AddReview(string MovieId, Guid userId, [FromBody]int? starReview, string? review)
        {
            ReviewModel newReview = new();
            newReview.UserId = userId;
            newReview.ReviewId = Guid.NewGuid();
            newReview.MovieId = MovieId;
            newReview.StarRating = starReview;
            newReview.Review = review;
            return Ok("Review sent");
        }

        // GET: ReviewController/Edit/5
        public IActionResult Edit(Guid Id, [FromBody]int? starReview, string? reviewcontent)
        {
            ReviewModel review = _reviewService.GetReviewById(Id);
            review.StarRating = starReview;
            review.Review = reviewcontent;
            return View();
        }

        [HttpDelete]
        //tt0111161
        public IActionResult DeleteReview(Guid Id)
        {
            _reviewService.Delete(Id);
            return Ok("Review removed!");
        }
    }
}
