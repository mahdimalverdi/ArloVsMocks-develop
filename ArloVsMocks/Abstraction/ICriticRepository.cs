using ArloVsMocks.Models;
using System.Collections.Generic;

namespace ArloVsMocks.Abstraction
{
    public interface ICriticRepository
    {
        IEnumerable<Critic> GetActiveCritics();
        double GetRatingWeight(int criticId);
    }
}