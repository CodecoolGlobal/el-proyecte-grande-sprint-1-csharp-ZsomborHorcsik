﻿using System.ComponentModel.DataAnnotations.Schema;

namespace FilmStock.Models.Entities
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CommentId;

        public long ReviewId;

        public long UserId;

        public string Comment;

        public DateTime Date;

        public DateTime? EditDate;

    }
}
