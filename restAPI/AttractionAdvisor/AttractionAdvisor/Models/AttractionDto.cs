namespace AttractionAdvisor.Models;

public class AttractionDto
{
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string ImageSource { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public List<Comment>? Comments { get; set; }
}