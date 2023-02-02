using System.Text.Json.Serialization;

namespace AttractionAdvisor.Models
{

    public class Rating
    {
        public int Id { get; set; }
        public int AttractionId { get; set; }

        [JsonIgnore]
        public Attraction? Attraction { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public User? User { get; set; }
        public ThumbsValue Value { get; set; }
    }

    public enum ThumbsValue
    {
        ThumbsUp = 1,
        ThumbsDown = 2
    }
}
