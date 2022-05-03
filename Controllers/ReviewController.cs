using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FilmStock.Models;

namespace FilmStock.Controllers
{
    [ApiController]
    public class ReviewController : Controller
    {
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
            ReviewModel review = _reviewService.GetReviewById(id);
            review.StarRating = starReview;
            review.Review = reviewcontent;
            return View();
        }

        [HttpDelete]
        //tt0111161
        public IActionResult DeleteReview(Guid Id)
        {
            _movieService.Remove(Id);
            return Ok("Review removed!");
        }
    }
}
