using Microsoft.EntityFrameworkCore;
using AttractionAdvisor.Models;

namespace AttractionAdvisor.data_access
{
    public class AttractionAdvisorDbContext: DbContext
    {
        public AttractionAdvisorDbContext(DbContextOptions<AttractionAdvisorDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Attraction> Attractions { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
