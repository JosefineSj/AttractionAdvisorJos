using AttractionAdvisor.DataAccess;
using AttractionAdvisor.Interfaces;
using AttractionAdvisor.Models;
using AttractionAdvisor.Utils;
using Microsoft.EntityFrameworkCore;

namespace AttractionAdvisor.Repository;

public class CommentRepository : ICommentRepository
{
    private readonly AttractionAdvisorDbContext _context;
        

    public CommentRepository(AttractionAdvisorDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Comment>> GetComments()
    {
        return await _context.Comments.ToListAsync();
    }

    public async Task<Comment?> GetComment(int id)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(
            c => c.Id == id);

        return comment ?? null;
    }

    public async Task<Comment> AddComment(Comment comment)
    {
        if (!Validation.IsValid(comment))
            throw new Exception("comment is not valid");
        
        var result = await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();
            
        return result.Entity;
    }

    public async Task<Comment?> UpdateComment(Comment comment)
    {
        var result = await _context.Comments
            .FirstOrDefaultAsync(c => c.Id == comment.Id);

        if (result == null)
            return null;

        if (!Validation.IsValid(comment))
            return null;
                    
        result.AttractionId = comment.AttractionId;
        result.UserId = comment.UserId;
        result.Commentary = comment.Commentary;

        await _context.SaveChangesAsync();

        return result;
    }
    public async Task<bool> DeleteComment(int id)
    {
        var result = await _context.Comments
            .FirstOrDefaultAsync(c => c.Id == id);
        if (result == null)
            return false;
            
        _context.Remove(result);
        await _context.SaveChangesAsync();

        return true;
    }
}