namespace AttractionAdvisor.Models
{
    public class Attraction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public IList<Rating> Ratings { get; set; }
        public IList<Comment> Comments { get; set; }
    }
}
