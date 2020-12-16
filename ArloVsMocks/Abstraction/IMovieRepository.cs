using ArloVsMocks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArloVsMocks.Abstraction
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
        double GetAverageRating(int movieId);
        void UpdateRange(IEnumerable<Movie> movies);
    }
}
