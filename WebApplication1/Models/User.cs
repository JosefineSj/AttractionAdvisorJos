namespace Provinceadvisor.Models
{
    public class User
    {
        public int Id { get;}
        public string Name { get;}
        public string UserName { get;}
        public string Password { get;  }

        public IList<Attraction> Attractions { get;}
        public IList<Rating> Ratings { get;}
        public IList<Comment> Comments { get;}
        

    }
}
