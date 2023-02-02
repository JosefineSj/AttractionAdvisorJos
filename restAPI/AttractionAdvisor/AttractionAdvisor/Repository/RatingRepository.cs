using AttractionAdvisor.DataAccess;
using AttractionAdvisor.Interfaces;
using AttractionAdvisor.Models;
using AttractionAdvisor.Utils;
using Microsoft.EntityFrameworkCore;

namespace AttractionAdvisor.Repository;

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

    public async Task<Rating?> GetRating(int id)
    {
        var result = await _context.Ratings.FirstOrDefaultAsync(
            r => r.Id == id);

        return result ?? null;
    }

    public async Task<Rating> AddRating(Rating rating)
    {
        if (!Validation.IsValid(rating))
            throw new Exception("rating is not valid");
        
        var result = await _context.Ratings.AddAsync(rating);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Rating?> UpdateRating(Rating rating)
    {
        var result = await _context.Ratings
            .FirstOrDefaultAsync(r => r.Id == rating.Id);

        if (result == null)
            return null;

        if (!Validation.IsValid(rating))
            return null;

        result.AttractionId = rating.AttractionId;
        result.UserId = rating.UserId;
        result.Value = rating.Value;

        await _context.SaveChangesAsync();

        return result;
    }

    public async Task<bool> DeleteRating(int id)
    {
        var result = await _context.Ratings
            .FirstOrDefaultAsync(r => r.Id == id);
        if (result == null)
            return false;
            
        _context.Remove(result);
        await _context.SaveChangesAsync();

        return true;
    }
}