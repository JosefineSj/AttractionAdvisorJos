using System.Text.Json.Serialization;

namespace AttractionAdvisor.Models
{
    public class Attraction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string ImageSource { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public User? User { get; set; }

        [JsonIgnore]
        public IList<Rating>? Ratings { get; set; }

        [JsonIgnore]
        public IList<Comment>? Comments { get; set; }
    }
}
