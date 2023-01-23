namespace AttractionAdvisor.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        private string _passwordHash { get; set; }

        public string Password { get; set; }    

        

        public void SetPassword(string password)
        {
            _passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool ValidatePassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, _passwordHash);
        }


        public IList<Attraction> Attractions { get; set; }
        public IList<Rating> Ratings { get; set; }
        public IList<Comment> Comments { get; set; }


    }

 

}
