using AttractionAdvisor.Models;
namespace AttractionAdvisor.Interfaces
{
    public interface IRatingRepository
    {
        Task<IEnumerable<Rating>> GetRatings();
        Task<Rating> GetRating(int id);
        Task<Rating> AddRating(Rating rating);
        Task<Rating> UpdateRating(Rating rating);
        Task<bool> DeleteRating(int id);
    }
}
