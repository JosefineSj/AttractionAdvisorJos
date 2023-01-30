using AttractionAdvisor.Models;

namespace AttractionAdvisor.Interfaces
{
    public interface IAttractionRepository
    {
        Task<List<AttractionDto>> GetAggregatedAttractions();
        Task<List<AttractionDto>> GetAggregatedAttractionsByUserId(int userId);
        Task<IEnumerable<Attraction>> GetAttractions();
        Task<Attraction?> GetAttraction(int id);
        Task<Attraction> AddAttraction(Attraction attraction);
        Task<Attraction?> UpdateAttraction(Attraction attraction);
        Task<bool> DeleteAttraction(int id);
    }
}
