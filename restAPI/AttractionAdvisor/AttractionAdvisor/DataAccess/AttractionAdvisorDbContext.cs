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
            
            modelBuilder.Entity<Rating>()
                .HasIndex(r => new { r.UserId, r.AttractionId })
                .IsUnique();

            modelBuilder.Entity<User>().HasData(
               new User
               {
                   Id = 1,
                   Username = "Sahar",
                   Password = BCrypt.Net.BCrypt.HashPassword("sah234")
               },
                  new User
                  {
                      Id = 2,
                      Username = "Hanna",
                   
                      Password = BCrypt.Net.BCrypt.HashPassword("han666")
                  }, new User
                  {
                      Id = 3,
                      Username = "Josefine",
                      Password = BCrypt.Net.BCrypt.HashPassword("jos3445")
                  }, new User
                  {
                      Id = 4,
                      Username = "Carl-Henrik",
                      Password = BCrypt.Net.BCrypt.HashPassword("ch44")
                  },
                     new User
                     {
                         Id = 5,
                         Username = "Kamran",
                         Password = BCrypt.Net.BCrypt.HashPassword("kam")
                     },
                     new User
                     {
                         Id = 6,
                         Username = "Jessica",
                         Password = BCrypt.Net.BCrypt.HashPassword("jsc432")
                     }, new User
                     {
                         Id = 7,
                         Username = "Alfons",
                         Password = BCrypt.Net.BCrypt.HashPassword("fanf51")
                     }, new User
                     {
                         Id = 8,
                         Username = "Sophie",
                         Password = BCrypt.Net.BCrypt.HashPassword("soph52")
                     }, new User
                     {
                         Id = 9,
                         Username = "Jenny",
                         Password = BCrypt.Net.BCrypt.HashPassword("je2n34")
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
                       City = "Göteborg",
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
                    , new Attraction
                    {
                        Id = 5,
                        Name = "Empire State Building",
                        City = "New York City",
                        Description = "Is a 102-story Art Deco skyscraper in Midtown Manhattan, New York City",
                        ImageSource = "https://lh5.googleusercontent.com/p/AF1QipNVlM5lo7fIJrmvjN4EOrTMiQjDgDyTfw7ATdV6=w243-h174-n-k-no-nu",
                        UserId = 5,
                    }
                      , new Attraction
                      {
                          Id = 6,
                          Name = "Great Pyramid of Giza",
                          City = "Cairo",
                          Description = "",
                          ImageSource = "https://media.architecturaldigest.com/photos/58e2a407c0e88d1a6a20066b/2:1/w_1287,h_643,c_limit/Pyramid%20of%20Giza%201.jpg",
                          UserId = 7,

                      }, new Attraction
                      {
                          Id = 7,
                          Name = "Colosseum",
                          City = "Rome",
                          Description = "The Colosseum is an oval amphitheatre in the centre of the city of Rome",
                          ImageSource = "https://jwttravel.ie/app/uploads/2022/04/Rome-Colosseum-travel-lessons-blog-JWT-Travel-Schools.jpg",
                          UserId = 8,

                      }, new Attraction
                      {
                          Id = 8,
                          Name = "Tower of London",
                          City = "London",
                          Description = "The Tower of London is an internationally famous monument and one of England's most iconic structures.",
                          ImageSource = "https://upload.wikimedia.org/wikipedia/commons/2/2c/Tower_of_London_viewed_from_the_River_Thames.jpg",
                          UserId = 3,

                      }, new Attraction
                      {
                          Id = 9,
                          Name = "Trevi Fountain",
                          City = "Rome",
                          Description = "Trevi Fountain is perhaps the most famous fountain in the world and definitely in Rome.",
                          ImageSource = "https://www.italiandualcitizenship.net/wp-content/uploads/2019/03/Historic-Trevi-Fountain-in-Rome-Italy.jpg",
                          UserId = 9,

                      }




                   );
            modelBuilder.Entity<Comment>().HasData(
                   new Comment
                   {
                       Id = 1,
                       AttractionId = 1,
                       UserId = 1,
                       Commentary = "I didn't expect such nice place at all.PErfect way to spend time in Stockholm."
                   },
                     new Comment
                     {   Id= 2,
                         AttractionId = 2,
                         UserId = 2,
                         Commentary = "Beautiful place and the kids enjoyed the few rides they could have, but they were dissapointed when they had to wait more than 2 hours to ride the rollercoaster."
                     },
                       new Comment
                       {
                            Id= 3,
                           AttractionId = 4,
                           UserId = 4,
                           Commentary = "You will spend half a day only to visit the Eiffel tower. The interest is huge and the crowds are humongous."
                       },
                          new Comment
                          {
                              Id = 4,
                              AttractionId = 3,
                              UserId = 6,
                              Commentary = "Oftast mycket intressanta utställningar,alltid gratis inträde och en gratis visning varje dag av kunniga guider"
                          },
                          new Comment
                          {
                              Id = 5,
                              AttractionId = 5,
                              UserId = 5,
                              Commentary = "Helt klart värt ett besök!Otroligt häftig film visas i hissen både påväg upp pch påväg ner vilket gör att man glömmer var man är påväg! Här finns inget att klaga på!"
                          },
                           new Comment
                           {
                               Id = 6,
                               AttractionId = 6,
                               UserId = 7,
                               Commentary = "Excellent visit Sunny January. Bring bottle of water and snack. Hat or a cap to protect ur head"

                           },new Comment
                           {
                               Id = 7,
                               AttractionId = 7,
                               UserId = 8,
                               Commentary = "Good but there aare so much better places in Rome. If you don't jave a lot of time in Rome dont go inside of it cause its a waste of time"

                           }, new Comment
                           {
                               Id = 8,
                               AttractionId = 8,
                               UserId = 3,
                               Commentary = "The history alone is a reason to go. Go early, the lines get long especially for the crown jewels! A lot of walking and narrow stairs and cobblestones.Plan on a good couple of hours here."
                           } ,new Comment
                           {
                               Id = 9,
                               AttractionId = 9,
                               UserId = 9,
                               Commentary = "This was on my bucket list & I can happily say it’s been done but it wasn’t the best time of day to visit (late afternoon in the height of Summer) as the crowds were thick."
                           }
 );
            modelBuilder.Entity<Rating>().HasData(
                   new Rating
                   {
                       Id = 1,
                       AttractionId = 1,
                       UserId = 1,
                       Value = (ThumbsValue)2,

                   }, new Rating
                   {
                       Id = 2,
                       AttractionId = 2,
                       UserId = 2,
                       Value = (ThumbsValue)2,

                   }, new Rating
                   {
                       Id = 3,
                       AttractionId = 3,
                       UserId = 6,
                       Value = (ThumbsValue)1,

                   }, new Rating
                   {
                       Id = 4,
                       AttractionId = 4,
                       UserId = 4,
                       Value = (ThumbsValue)1,

                   }, new Rating
                   {
                       Id = 5,
                       AttractionId = 5,
                       UserId = 5,
                       Value = (ThumbsValue)1,

                   }, new Rating
                   {
                       Id = 6,
                       AttractionId = 6,
                       UserId =7,
                       Value = (ThumbsValue)1,

                   }, new Rating
                   {
                       Id = 7,
                       AttractionId = 7,
                       UserId = 8,
                       Value = (ThumbsValue)2,

                   }, new Rating
                   {
                       Id = 8,
                       AttractionId = 8,
                       UserId = 3,
                       Value = (ThumbsValue)1,

                   }, new Rating
                   {
                       Id = 9,
                       AttractionId = 9,
                       UserId = 9,
                       Value = (ThumbsValue)2,

                   }
                   );




        }
    }
}
