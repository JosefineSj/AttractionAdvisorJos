using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json.Serialization;

namespace AttractionAdvisor.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }    

        public void SetPassword(string password)
        {
            Password = BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool ValidatePassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, Password);
        }

        [JsonIgnore]
        public IList<Attraction>? Attractions { get; set; }
        [JsonIgnore]
        public IList<Rating>? Ratings { get; set; }
        [JsonIgnore]
        public IList<Comment>? Comments { get; set; }
    }
}
