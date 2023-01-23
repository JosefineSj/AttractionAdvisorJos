namespace AttractionAdvisor.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }    

        public void SetPassword(string password)
        {
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool ValidatePassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
        }

        public IList<Attraction> Attractions { get; set; }
        public IList<Rating> Ratings { get; set; }
        public IList<Comment> Comments { get; set; }
        public static bool ValidateUser(User user)
        {
            if (String.IsNullOrEmpty(user.UserName))
                return false;
            
            if (String.IsNullOrEmpty(user.PasswordHash))
                return false;
            
            return true;
        }
    }
}
