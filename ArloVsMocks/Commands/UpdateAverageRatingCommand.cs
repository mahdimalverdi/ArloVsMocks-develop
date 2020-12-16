using ArloVsMocks.Abstraction;
using ArloVsMocks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArloVsMocks
{
    public class UpdateAverageRatingCommand
    {

        private readonly IMovieRepository movieRepository;

        public UpdateAverageRatingCommand(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
        }

        public void Execute()
        {
            var movies = movieRepository.GetAll();

            foreach (var movie in movies)
            {
                movie.AverageRating = CalculateAverageRating(movie.Ratings);
            }
        }

        private static double CalculateAverageRating(ICollection<Rating> ratings)
        {
            var weightTotal = ratings.Select(r => r.Critic.RatingWeight).Sum();
            var ratingTotal = ratings.Select(r => r.Stars * r.Critic.RatingWeight).Sum();

            return ratingTotal / weightTotal;
        }

    }
}
