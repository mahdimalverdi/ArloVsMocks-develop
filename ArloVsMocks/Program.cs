using System;
using System.Linq;
using ArloVsMocks.Data;

namespace ArloVsMocks
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var manager = new MovieManger();
                manager.Execute();
                var report = manager.GetNewRating();

                Console.WriteLine("New critic rating weight: {0:N1}", report.CriticRatingWeight);
                Console.WriteLine("New movie rating: {0:N1}", report.MovieRating);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
