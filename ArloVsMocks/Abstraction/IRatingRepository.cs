using ArloVsMocks.Models;

namespace ArloVsMocks.Abstraction
{
    public interface IRatingRepository
    {
        Rating GetOrCreate(int movieId, int criticId);
        void UpdateOrCreate(int movieId, int criticId, int stars);
    }
}