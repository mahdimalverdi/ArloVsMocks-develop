using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArloVsMocks
{
    public class RatingItem
    {
        public RatingItem(double newCriticRatingWeight, double newMovieRating)
        {
            CriticRatingWeight = newCriticRatingWeight;
            MovieRating = newMovieRating;
        }

        public double CriticRatingWeight { get; }
        public double MovieRating { get; }
    }
}
