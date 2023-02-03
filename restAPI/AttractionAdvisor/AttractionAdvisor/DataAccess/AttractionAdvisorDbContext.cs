using Microsoft.EntityFrameworkCore;
using AttractionAdvisor.Models;

namespace AttractionAdvisor.DataAccess
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Attractions)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Ratings)
                .WithOne(r => r.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Attraction>()
                .HasMany(a => a.Comments)
                .WithOne(c => c.Attraction)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Attraction>()
                .HasMany(a => a.Ratings)
                .WithOne(r => r.Attraction)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                 .HasOne(c => c.Attraction)
                 .WithMany(a => a.Comments)
                 .HasForeignKey(a => a.UserId)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Attraction)
                .WithMany(a => a.Ratings)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.User)
                .WithMany(u => u.Ratings)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>().HasData(
               new User
               {
                   Id = 1,
                   Username = "Sahar",
                   Password = "saha68"
               },
                  new User
                  {
                      Id = 2,
                      Username = "Hanna",
                      Password = "han53"
                  }, new User
                  {
                      Id = 3,
                      Username = "Josefin",
                      Password = "jos22"
                  }, new User
                  {
                      Id = 4,
                      Username = "Carl-Henrik",
                      Password = "ch111"
                  },
                     new User
                     {
                         Id = 5,
                         Username = "Kamran",
                         Password = "kam33"
                     },
                     new User
                     {
                         Id = 6,
                         Username = "Jessica",
                         Password = "js44"
                     }, new User
                     {
                         Id = 7,
                         Username = "Alfons",
                         Password = "ty6y7"
                     }



               ); modelBuilder.Entity<Attraction>().HasData(
                   new Attraction
                   {
                       Id = 1,
                       Name = "Skansen",
                       City = "Stockholm",
                       Description = "The world's oldest open-air museum",
                       ImageSource = "https://skansen.se/wp-content/uploads/2022/10/Hazeliusporten_skansen-600x450.jpg",
                       UserId = 1,
                   },
                   new Attraction
                   {
                       Id = 2,
                       Name = "Liseberg",
                       City = "Götebog",
                       Description = "Amusement park in the centre of Gothenburg",
                       ImageSource = "https://www.liseberg.se/optimized/facebook/046e6139/globalassets/parken/parkvyer/hela-parken-vy.jpg",
                       UserId = 2,
                   }, new Attraction
                   {
                       Id = 3,
                       Name = "Malmö Art Museum",
                       City = "Malmö",
                       Description = "One of the leading art museums in scandinavia",
                       ImageSource = "https://upload.wikimedia.org/wikipedia/commons/e/ea/Malmo_art_museum-malmo_castle.jpg",
                       UserId = 6,
                   }
                   , new Attraction
                   {
                       Id = 4,
                       Name = "Eiffel tower",
                       City = "Paris",
                       Description = "Wrought-iron tower on the Champ de Mars in Paris",
                       ImageSource = "https://cdn.britannica.com/54/75854-050-E27E66C0/Eiffel-Tower-Paris.jpg",
                       UserId = 4,
                   }



                   
                   );
        }
    }
}
