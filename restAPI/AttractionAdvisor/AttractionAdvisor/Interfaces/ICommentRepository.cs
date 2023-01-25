
using AttractionAdvisor.Models;

namespace AttractionAdvisor.Interfaces
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetComments();
        Task<Comment?> GetComment(int id);
        Task<Comment> AddComment(Comment comment);
        Task<Comment?> UpdateComment(Comment comment);
        Task<bool> DeleteComment(int id);
    }
}
