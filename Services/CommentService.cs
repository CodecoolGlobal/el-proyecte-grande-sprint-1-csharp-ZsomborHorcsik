using FilmStock.Models;
using FilmStock.Daos;

namespace FilmStock.Services
{
    public class CommentService
    {
        private readonly ICommentDao _commentDao;

        public CommentService(ICommentDao commetnDao)
        {
            _commentDao = commetnDao;
        }

        public void Add(CommentModel comment)
        {
            _commentDao.Add(comment);
        }

        public void Delete(Guid commentId)
        {
            _commentDao.Delete(commentId);
        }

        public IEnumerable<CommentModel> GetCommentsByUser(Guid id)
        {
            var comments = _commentDao.GetCommentsByUser(id);
            return comments;
        }

        public CommentModel GetCommentById(Guid id)
        {
            return _commentDao.GetCommentById(id);
        }
    }
}
