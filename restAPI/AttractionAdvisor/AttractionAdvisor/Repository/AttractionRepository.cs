using AttractionAdvisor.DataAccess;
using AttractionAdvisor.Interfaces;
using AttractionAdvisor.Models;
using Microsoft.EntityFrameworkCore;

namespace AttractionAdvisor.Repository
{
    public class AttractionRepository : IAttractionRepository
    {
        private readonly AttractionAdvisorDbContext _context;
        public AttractionRepository(AttractionAdvisorDbContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<Attraction>> GetAttractions()
        {
            return await _context.Attractions.ToListAsync();
        }

        public async Task<Attraction?> GetAttraction(int id)
        {
            var result = await _context.Attractions.FirstOrDefaultAsync(
                a => a.Id == id);
            

            return result ?? null;

        }

        public async Task<Attraction> AddAttraction(Attraction attraction)
        {
            var result = await _context.Attractions.AddAsync(attraction);
            await _context.SaveChangesAsync();
            
            return result.Entity;
        }

        public async Task<Attraction?> UpdateAttraction(Attraction attraction)
        {
            var result = await _context.Attractions
               .FirstOrDefaultAsync(a => a.Id == attraction.Id);

            if (result == null)
                return null; 

            result.Name = attraction.Name;
            result.City = attraction.City;
            result.Description = attraction.Description;
            result.ImageSource = attraction.ImageSource;

            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAttraction(int id)
        {
            var result = await _context.Attractions.FirstOrDefaultAsync(a => a.Id==id);

            if (result == null)
                return false;

            _context.Attractions.Remove(result);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
