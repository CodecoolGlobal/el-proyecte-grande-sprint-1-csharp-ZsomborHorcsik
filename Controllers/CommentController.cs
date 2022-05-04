using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FilmStock.Models;
using FilmStock.Services;

namespace FilmStock.Controllers
{
    [ApiController]
    public class CommentController : Controller
    {
        private readonly CommentService _commentService;

        public CommentController(CommentService commentService)
        {
            _commentService = commentService;
        }

        // POST: ReviewController/Create
        [HttpPost]
        public IActionResult AddComment(Guid reviewId, Guid userId, [FromBody] string comment)
        {
            CommentModel newComment = new();
            newComment.ReviewId = reviewId;
            newComment.UserId = userId;
            newComment.CommentId = Guid.NewGuid();
            newComment.Comment = comment;
            return Ok("Review sent");
        }

        // GET: CommentController/Edit/5
        public IActionResult Edit(Guid Id, [FromBody]string? commentContent)
        {
            CommentModel comment = _commentService.GetCommentById(Id);
            comment.Comment = commentContent;
            return Ok();
        }

        [HttpDelete]
        //tt0111161
        public IActionResult DeleteReview(Guid Id)
        {
            _commentService.Delete(Id);
            return Ok("Review removed!");
        }
    }
}
