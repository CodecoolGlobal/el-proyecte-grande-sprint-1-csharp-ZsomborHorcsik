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

        [HttpPost("/AddComment")]
        public IActionResult AddComment(Guid reviewId, Guid userId, [FromBody] string comment)
        {
            CommentModel newComment = new();
            newComment.ReviewId = reviewId;
            newComment.UserId = userId;
            newComment.CommentId = Guid.NewGuid();
            newComment.Comment = comment;
            newComment.Date = DateTime.Now;
            return Ok("Review sent");
        }

        [HttpPut("/EditComment/{Id}")]
        public IActionResult EditComment(Guid Id, [FromBody]string? commentContent)
        {
            CommentModel comment = _commentService.GetCommentById(Id);
            comment.Comment = commentContent;
            comment.EditDate = DateTime.Now;
            return Ok();
        }

        [HttpDelete("/DeleteComment/{Id}")]
        public IActionResult DeleteReview(Guid Id)
        {
            _commentService.Delete(Id);
            return Ok("Review removed!");
        }
    }
}
