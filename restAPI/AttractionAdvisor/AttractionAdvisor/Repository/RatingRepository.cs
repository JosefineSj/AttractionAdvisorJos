using AttractionAdvisor.DataAccess;
using AttractionAdvisor.Interfaces;
using AttractionAdvisor.Models;
using Microsoft.EntityFrameworkCore;

namespace AttractionAdvisor.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly AttractionAdvisorDbContext _context;

        public RatingRepository(AttractionAdvisorDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Rating>> GetRatings()
        {
            return await _context.Ratings.ToListAsync();
        }
        public async Task<Rating> GetRating(int id)
        {
            return await _context.Ratings.FirstOrDefaultAsync(r => r.Id == id);

        }
        public async Task<Rating> AddRating(Rating rating)
        {
            var result = await _context.Ratings.AddAsync(rating);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Rating> UpdateRating(Rating rating)
        {
            var result = await _context.Ratings
               .FirstOrDefaultAsync(r => r.Id == rating.Id);

            if (result != null)
            {
                result.AttractionId = rating.AttractionId;
                result.UserId = rating.UserId;
                result.Rank = rating.Rank;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }
        public async void DeleteRating(int id)
        {
            var result = await _context.Ratings
                .FirstOrDefaultAsync(r => r.Id == id);
            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
    }
}
