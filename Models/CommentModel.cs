﻿namespace FilmStock.Models
{
    public class CommentModel
    {
        public Guid CommentId;

        public Guid ReviewId;

        public Guid UserId;

        public string Comment;
    }
}
