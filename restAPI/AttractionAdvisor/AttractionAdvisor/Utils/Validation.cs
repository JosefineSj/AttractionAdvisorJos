using AttractionAdvisor.Models;

namespace AttractionAdvisor.Utils;

public class Validation
{
    public static bool ValdiateAttraction(Attraction attraction)
    {
        if (String.IsNullOrEmpty(attraction.Name))
            return false;

        if (String.IsNullOrEmpty(attraction.City))
            return false;

        if (String.IsNullOrEmpty(attraction.Description))
            return false;

        if (String.IsNullOrEmpty(attraction.ImageSource))
            return false;
        
        return true;
    }

    public static bool ValidateComment(Comment comment)
    {
        if (comment.AttractionId <= 0)
            return false;

        if (comment.UserId <= 0)
            return false;

        if (String.IsNullOrEmpty(comment.Commentary))
            return false;

        return true;
    }

    public bool ValidateRating(Rating rating)
    {
        if (rating.AttractionId <= 0)
            return false;

        if (rating.UserId <= 0)
            return false;

        return true;
    }

    public static bool ValidateUser(User user)
    {
        if (String.IsNullOrEmpty(user.Username))
            return false;
        
        if (String.IsNullOrEmpty(user.Password))
            return false;
        
        return true;
    }
}
