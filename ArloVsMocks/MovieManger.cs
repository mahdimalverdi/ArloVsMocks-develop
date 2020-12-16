using ArloVsMocks.Abstraction;
using ArloVsMocks.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace ArloVsMocks
{
    public class MovieManger
    {
        private readonly IMovieRepository movieRepository;
        private readonly ICriticRepository criticRepository;
        private readonly IRatingRepository ratingRepository;

        public MovieManger(
            IMovieRepository movieRepository,
            ICriticRepository criticRepository,
            IRatingRepository ratingRepository)
        {
            this.movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
            this.criticRepository = criticRepository ?? throw new ArgumentNullException(nameof(criticRepository));
            this.ratingRepository = ratingRepository ?? throw new ArgumentNullException(nameof(ratingRepository));
        }

        public void AddRating(int movieId, int criticId, int stars)
        {
            UpsertRating(movieId, criticId, stars);
            UpdateRatingWeight();
            UpdateAverageRating();
        }

        private void UpdateAverageRating()
        {
            new UpdateAverageRatingCommand(movieRepository).Execute();
        }

        private void UpdateRatingWeight()
        {
            new UpdateRatingWeightCommand(criticRepository).Execute();
        }

        public RatingItem GetNewRating(int movieId, int criticId)
        {
            var newCriticRatingWeight = criticRepository.GetRatingWeight(criticId);
            var newMovieRating = movieRepository.GetAverageRating(movieId);
            return new RatingItem(newCriticRatingWeight, newMovieRating);
        }

        private void UpsertRating(int movieId, int criticId, int stars)
        {
            ratingRepository.UpdateOrCreate(movieId, criticId, stars);
        }
    }
}
