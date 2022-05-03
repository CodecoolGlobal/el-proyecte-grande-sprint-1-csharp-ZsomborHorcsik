using FilmStock.Models;
using FilmStock.Daos;

namespace FilmStock.Services
{
    public class CommentService
    {
        private readonly ICommentDao _commetnDao;

        public CommentService(ICommentDao commetnDao)
        {
            _commetnDao = commetnDao;
        }

        public void Add(CommentModel comment)
        {
            _commetnDao.Add(comment);
        }

        public void Delete(Guid commentId)
        {
            _commetnDao.Delete(commentId);
        }

        public IEnumerable<CommentModel> GetCommentsByUser(Guid id)
        {
            var comments = _commetnDao.GetCommentsByUser(id);
            return comments;
        }
    }
}
