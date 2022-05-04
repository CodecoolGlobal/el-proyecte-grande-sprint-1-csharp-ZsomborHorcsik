using FilmStock.Models;

namespace FilmStock.Daos
{
    public interface ICommentDao
    {
        void Add(CommentModel movie);
        void Delete(Guid reviewId);
        IEnumerable<CommentModel> GetCommentsByUser(Guid id);
        CommentModel GetCommentById(Guid id);
    }
}
