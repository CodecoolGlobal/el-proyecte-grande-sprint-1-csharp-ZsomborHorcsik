﻿using FilmStock.Models;
using FilmStock.Daos.Implementations;

namespace FilmStock.Services
{
    public class ReviewService
    {
        private readonly IReviewDao _reviewDao;

        public ReviewService(IReviewDao reviewDao)
        {
            _reviewDao = reviewDao;
        }

        public void Add(ReviewModel movie)
        {
            _reviewDao.Add(movie);
        }

        public void Delete(Guid reviewId)
        {
            _reviewDao.Remove(reviewId);
        }

        public IEnumerable<ReviewModel> GetReviewsByUser(Guid id)
        {
            var reviews = _reviewDao.Where(review => review.UserId == id);
            return reviews;
        }
    }
}