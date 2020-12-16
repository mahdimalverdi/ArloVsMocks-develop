using ArloVsMocks.Abstraction;
using ArloVsMocks.Data;
using ArloVsMocks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArloVsMocks
{
    public class CriticRepository : ICriticRepository
    {
        private readonly MovieReviewEntities db;

        public CriticRepository(MovieReviewEntities db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IEnumerable<Critic> GetActiveCritics()
        {
            return db.Critics.Where(c => c.Ratings.Count > 0).ToList();
        }

        public double GetRatingWeight(int criticId)
        {
            return db.Critics.Where(c => c.Id == criticId).Select(c => c.RatingWeight).Single();
        }
    }
}
