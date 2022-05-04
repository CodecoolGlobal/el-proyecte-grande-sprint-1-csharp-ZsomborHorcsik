using FilmStock.Models;

namespace FilmStock.Daos.Implementations
{
    public class CommentDaoMemory : ICommentDao
    {
        private readonly List<CommentModel> _data = new() { };

        public CommentDaoMemory()
        {
        }

        public void Add(CommentModel comment)
        {
            _data.Add(comment);
        }

        public void Delete(Guid id)
        {
            _data.Remove(_data.Single(comment => comment.CommentId == id));
        }

        public CommentModel GetCommentById(Guid id)
        {
            return _data.Where(comment => comment.CommentId == id).First();
        }

        public IEnumerable<CommentModel> GetCommentsByUser(Guid id)
        {
            var comments = _data.Where(comment => comment.UserId == id);
            return comments;
        }
    }
}
