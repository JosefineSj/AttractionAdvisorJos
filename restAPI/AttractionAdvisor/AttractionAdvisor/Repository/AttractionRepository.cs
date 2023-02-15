using AttractionAdvisor.DataAccess;
using AttractionAdvisor.Interfaces;
using AttractionAdvisor.Models;
using AttractionAdvisor.Utils;
using Microsoft.EntityFrameworkCore;

namespace AttractionAdvisor.Repository;

public class AttractionRepository : IAttractionRepository
{
    private readonly AttractionAdvisorDbContext _context;
    public AttractionRepository(AttractionAdvisorDbContext context)
    {
        _context = context;
    }
        
    public async Task<List<AttractionDto>> GetAllAttractionDto()
    {
        var allAttractions = await _context.Attractions
            .Include(a => a.Comments)
            .ThenInclude(a => a.User)
            .ToListAsync();

        var allAttractionDto = allAttractions.Select(a => new AttractionDto
        {
            Id = a.Id,
            Name = a.Name,
            City = a.City,
            Description = a.Description,
            ImageSource = a.ImageSource,
            Comments = a.Comments != null
                ? a.Comments.Select(c => new CommentDto
                {
                    Username = c.User?.Username ?? string.Empty,
                    Comment = c.Commentary
                }).ToList()
                : new List<CommentDto>()
        }).ToList();

        foreach (var attraction in allAttractionDto)
        {
            attraction.Dislikes = await _context.Ratings.CountAsync(
                r => r.AttractionId == attraction.Id 
                     && r.Value == ThumbsValue.ThumbsDown);
                
            attraction.Likes = await _context.Ratings.CountAsync(
                r => r.AttractionId == attraction.Id 
                     && r.Value == ThumbsValue.ThumbsUp);
        }
        return allAttractionDto;
    }
        
    public async Task<List<AttractionDto>> GetAllAttractionDtoByUserId(int userId)
    {
        var allAttractionDto = await _context.Attractions
            .Where(a => a.UserId == userId)
            .Include(a => a.Comments)
            .Select(a => new AttractionDto
            {
                Id = a.Id,
                Name = a.Name,
                City = a.City,
                Description = a.Description,
                ImageSource = a.ImageSource,
                Comments = a.Comments!.Where(c => c.UserId == userId).
                    Select(c => new CommentDto
                    {
                        Username = c.User!.Username,
                        Comment = c.Commentary
                    }).ToList()
            })
            .ToListAsync();

        foreach (var attraction in allAttractionDto)
        {
            attraction.Dislikes = await _context.Ratings.Where(
                r => r.AttractionId == attraction.Id 
                     && r.Value == ThumbsValue.ThumbsDown).CountAsync();
                
            attraction.Likes = await _context.Ratings.Where(
                r => r.AttractionId == attraction.Id 
                     && r.Value == ThumbsValue.ThumbsUp).CountAsync();
        }
            
        return allAttractionDto;
    }

    public async Task<AttractionDto?> GetAttractionDto(int id)
    {
        var attraction = await _context.Attractions
            .Include(a => a.Comments)
            .ThenInclude(a => a.User)
            .FirstOrDefaultAsync(a => a.Id == id);
        
        if (attraction == null)
        {
            return null;
        }
        
        var attractionDto = new AttractionDto
        {
            Id = attraction.Id,
            Name = attraction.Name,
            City = attraction.City,
            Description = attraction.Description,
            ImageSource = attraction.ImageSource,
            Comments = attraction.Comments?
                .Select(c => new CommentDto
                {
                    Username = c.User?.Username ?? string.Empty,
                    Comment = c.Commentary
                })
                .ToList() ?? new List<CommentDto>()
        };
        
        attractionDto.Likes = await _context.Ratings.CountAsync(
            r => r.AttractionId == attractionDto.Id 
                 && r.Value == ThumbsValue.ThumbsUp);
                
        attractionDto.Dislikes = await _context.Ratings.CountAsync(
            r => r.AttractionId == attractionDto.Id 
                 && r.Value == ThumbsValue.ThumbsDown);
        
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
        if (!Validation.IsValid(attraction))
            throw new Exception("not a valid attraction");
                
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

        if (!Validation.IsValid(attraction))
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