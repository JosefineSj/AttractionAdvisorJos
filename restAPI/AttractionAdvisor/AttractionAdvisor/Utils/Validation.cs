using AttractionAdvisor.DataAccess;
using AttractionAdvisor.Models;

namespace AttractionAdvisor.Utils;

public class Validation
{
    private static AttractionAdvisorDbContext _context;

    public Validation(AttractionAdvisorDbContext context)
    {
        _context = context;
    }

    public static bool IsValid(Attraction attraction)
    {
        if (string.IsNullOrEmpty(attraction.Name))
            return false;

        if (string.IsNullOrEmpty(attraction.City))
            return false;

        if (string.IsNullOrEmpty(attraction.Description))
            return false;

        if (attraction.UserId <= 0)
            return false;

        return !string.IsNullOrEmpty(attraction.ImageSource);
    }

    public static bool IsValid(Comment comment)
    {
        if (comment.AttractionId <= 0)
            return false;

        if (comment.UserId <= 0)
            return false;

        return !string.IsNullOrEmpty(comment.Commentary);
    }

    public static bool IsValid(Rating rating)
    {
        if (rating.AttractionId <= 0)
            return false;

        return rating.UserId > 0;
    }

    public static bool IsValid(User user)
    {
        if (string.IsNullOrEmpty(user.Username))
            return false;
        
        return !string.IsNullOrEmpty(user.Password);
    }
}
