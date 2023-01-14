namespace AttractionAdvisor.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public IList<Attraction> Attractions { get; set; }
        public IList<Rating> Ratings { get; set; }
        public IList<Comment> Comments { get; set; }
        

    }
}
