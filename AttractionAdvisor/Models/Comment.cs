namespace AttractionAdvisor.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int AttractionId { get; set; }
        public Attraction Attraction { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Commentary { get; set; }
    }
}
