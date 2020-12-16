using ArloVsMocks.Abstraction;
using ArloVsMocks.Data;
using ArloVsMocks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArloVsMocks
{
    public class RatingRepository : IRatingRepository
    {
        private readonly MovieReviewEntities db;

        public Rating GetOrCreate(int movieId, int criticId)
        {
            var existingRating = db.Ratings.SingleOrDefault(r => r.MovieId == movieId && r.CriticId == criticId);
            return existingRating ?? Add(movieId, criticId);
        }

        private Rating Add(int movieId, int criticId)
        {
            Rating existingRating = new Rating { MovieId = movieId, CriticId = criticId };
            db.Ratings.Add(existingRating);
            return existingRating;
        }

        public void UpdateOrCreate(int movieId, int criticId, int stars)
        {
            var existingRating = GetOrCreate(movieId, criticId);
            existingRating.Stars = stars;
            db.SaveChanges();
        }
    }
}
