using AttractionAdvisor.Models;

namespace AttractionAdvisor.Interfaces
{
    public interface IAttractionRepository
    {
        Task<List<AttractionDto>> GetAllAttractionDto();
        Task<AttractionDto?> GetAttractionDto(int id);
        Task<List<AttractionDto>> GetAllAttractionDtoByUserId(int userId);
        Task<IEnumerable<Attraction>> GetAttractions();
        Task<Attraction?> GetAttraction(int id);
        Task<Attraction> AddAttraction(Attraction attraction);
        Task<Attraction?> UpdateAttraction(Attraction attraction);
        Task<bool> DeleteAttraction(int id);
    }
}
