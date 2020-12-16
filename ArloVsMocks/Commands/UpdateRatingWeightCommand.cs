using ArloVsMocks.Abstraction;
using ArloVsMocks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArloVsMocks
{
    public class UpdateRatingWeightCommand
    {
        private readonly ICriticRepository criticRepository;

        public UpdateRatingWeightCommand(ICriticRepository criticRepository)
        {
            this.criticRepository = criticRepository ?? throw new ArgumentNullException(nameof(criticRepository));
        }

        public void Execute()
        {
            var criticsHavingRated = criticRepository.GetActiveCritics();

            foreach (var critic in criticsHavingRated)
            {
                double relativeDisparity = GetRealativeDisparity(critic.Ratings);
                critic.RatingWeight = GetRatingWeight(relativeDisparity);
            }
        }

        private static double GetRatingWeight(double relativeDisparity)
        {
            if (relativeDisparity > 2)
            {
                return 0.15;
            }
            if (relativeDisparity > 1)
            {
                return 0.33;
            }
            return 1;
        }

        private static double GetRealativeDisparity(IEnumerable<Rating> ratings)
        {
            var ratingsWithAverages = ratings.Where(r => r.Movie.AverageRating.HasValue);
            var totalDisparity = ratingsWithAverages.Average(r => Math.Abs(r.Stars - r.Movie.AverageRating.Value));
            return totalDisparity;
        }
    }
}
