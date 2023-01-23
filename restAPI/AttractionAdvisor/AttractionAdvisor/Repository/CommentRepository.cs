using AttractionAdvisor.DataAccess;
using AttractionAdvisor.Interfaces;
using AttractionAdvisor.Models;
using Microsoft.EntityFrameworkCore;

namespace AttractionAdvisor.Repository
{
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

        public async Task<Comment> GetComment(int id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(
                    c => c.Id == id);
            if (comment == null)
                throw new Exception("not found");

            return comment;
        }

        public async Task<Comment> AddComment(Comment comment)
        {
            var result = await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            
            return result.Entity;
        }

        public async Task<Comment> UpdateComment(Comment comment)
        {
            var result = await _context.Comments
               .FirstOrDefaultAsync(c => c.Id == comment.Id);

            if (result == null)
                throw new Exception("comment not found");
                    
            result.AttractionId = comment.AttractionId;
            result.UserId = comment.UserId;
            result.Commentary = comment.Commentary;

            await _context.SaveChangesAsync();

            return result;
        }
        public async void DeleteComment(int id)
        {
            var result = await _context.Comments
                .FirstOrDefaultAsync(c => c.Id == id);
            if (result != null)
                throw new Exception("comment not found");
            
            _context.Remove(result);
            await _context.SaveChangesAsync();
        }
    }
}