using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public IList<Attraction>? Attractions { get; set; }
        [JsonIgnore]
        public IList<Rating>? Ratings { get; set; }
        [JsonIgnore]
        public IList<Comment>? Comments { get; set; }
    }
}
