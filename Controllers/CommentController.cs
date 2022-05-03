using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FilmStock.Models;

namespace FilmStock.Controllers
{
    public class CommentController : Controller
    {
        // POST: ReviewController/Create
        [HttpPost]
        public IActionResult AddComment(Guid reviewId, Guid userId [FromBody] string comment)
        {
            CommentModel newComment = new();
            newComment.ReviewId = reviewId;
            newComment.UserId = userId;
            newComment.CommentId = Guid.NewGuid();
            newComment.Comment = comment;

            return Ok("Review sent");
        }

        // GET: CommentController/Edit/5
        public IActionResult Edit(Guid Id, [FromBody]string? reviewcontent)
        {
            CommentModel comment = _comment.GetReviewById(id);
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
