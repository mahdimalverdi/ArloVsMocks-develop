using ArloVsMocks.Abstraction;
using ArloVsMocks.Data;
using ArloVsMocks.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace ArloVsMocks
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieReviewEntities db;

        public MovieRepository(MovieReviewEntities db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IEnumerable<Movie> GetAll()
        {
            return db.Movies;
        }

        public void UpdateRange(IEnumerable<Movie> movies)
        {
            foreach (var movie in movies)
            {

            }
        }

        public double GetAverageRating(int movieId)
        {
            return db.Movies.Where(m => m.Id == movieId).Select(m => m.AverageRating.Value).Single();
        }

        public void UpdateAverageRating(IEnumerable<MovieRating> movieRatings)
        {
            var moviesDic = movieRatings.ToDictionary(m => m.MovieId);
            var movies = db.Movies.Where(m => moviesDic.Keys.Contains(m.Id)).ToList();


        }
    }
}
