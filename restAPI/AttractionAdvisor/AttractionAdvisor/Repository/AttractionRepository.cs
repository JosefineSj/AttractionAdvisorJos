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
        
        public async Task<List<AttractionDto>> GetAllAttractionDto()
        {
            var allAttractionDto = await _context.Attractions
                .Include(a => a.Ratings)
                .Include(a => a.Comments)
                .Select(a => new AttractionDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    City = a.City,
                    Description = a.Description,
                    ImageSource = a.ImageSource,
                    Ratings = a.Ratings!.ToList(),
                    Comments = a.Comments!.ToList()
                })
                .ToListAsync();

            return allAttractionDto;
        }
        
        public async Task<List<AttractionDto>> GetAllAttractionDtoByUserId(int userId)
        {
            var allAttractionDto = await _context.Attractions
                .Where(a => a.Comments != null && a.Ratings != null && (a.Ratings.Any(
                    r => r.UserId == userId) || a.Comments.Any(c => c.UserId == userId)))
                .Include(a => a.Ratings)
                .Include(a => a.Comments)
                .Select(a => new AttractionDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    City = a.City,
                    Description = a.Description,
                    ImageSource = a.ImageSource,
                    Ratings = a.Ratings!.Where(r => r.UserId == userId).ToList(),
                    Comments = a.Comments!.Where(c => c.UserId == userId).ToList()
                })
                .ToListAsync();

            return allAttractionDto;
        }

        public async Task<AttractionDto?> GetAttractionDto(int id)
        {
            var attractionDto = await _context.Attractions
                .Where(a => a.Comments != null && a.Ratings != null && (a.Ratings.Any(
                    r => r.UserId == id) || a.Comments.Any(c => c.UserId == id)))
                .Include(a => a.Ratings)
                .Include(a => a.Comments)
                .Select(a => new AttractionDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    City = a.City,
                    Description = a.Description,
                    ImageSource = a.ImageSource,
                    Ratings = a.Ratings!.Where(r => r.UserId == id).ToList(),
                    Comments = a.Comments!.Where(c => c.UserId == id).ToList()
                })
                .FirstOrDefaultAsync();

            return attractionDto;
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
