using Microsoft.EntityFrameworkCore;
using AttractionAdvisor.Models;
using Bogus;

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
                 .HasForeignKey(a => a.AttractionId)
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

            var attractionName = new[] { "Skansen", "Liseberg", "Eiffel tower", "Empire State Building", "Great Pyramid of Giza" };
            
            var idsU = 1;
            var users = new Faker<User>()
                    .RuleFor(c => c.Id, f => idsU++)
                    .RuleFor(u => u.Username, f => f.Person.UserName)
                    .RuleFor(u => u.Password, f => BCrypt.Net.BCrypt.HashPassword(f.Internet.Password()));

            var usersList = users.GenerateBetween(500, 500);

            var idsA = 1;
            var attractions = new Faker<Attraction>()
                .RuleFor(a => a.Id, f => idsA++)
                .RuleFor(a => a.Name, f => f.PickRandom(attractionName))
                .RuleFor(a => a.City, f => f.Address.City())
                .RuleFor(a => a.Description, f => f.Lorem.Sentence(10))
                .RuleFor(a => a.ImageSource, f => f.Image.PicsumUrl())
                .RuleFor(a => a.UserId, f => f.PickRandom(usersList).Id);

            var attractionsList = attractions.GenerateBetween(500, 500);

            var idsC = 1;
            var comments = new Faker<Comment>()
                .RuleFor(c => c.Id, f => idsC++)
                .RuleFor(c => c.Commentary, f => f.Lorem.Sentence())
                .RuleFor(c => c.UserId, f => f.PickRandom(usersList).Id)
                .RuleFor(c => c.AttractionId, f => f.PickRandom(attractionsList).Id);
            var idsR = 1;
            var ratings = new Faker<Rating>()
                .RuleFor(c => c.Id, f => idsR++)
                .RuleFor(r => r.Value, f => f.PickRandom<ThumbsValue>())
                .RuleFor(r => r.UserId, f => f.PickRandom(usersList).Id)
                .RuleFor(r => r.AttractionId, f => f.PickRandom(attractionsList).Id);
          

            modelBuilder
            .Entity<User>()
            .HasData(usersList);
             modelBuilder
            .Entity<Attraction>()
            .HasData(attractionsList);
             modelBuilder
            .Entity<Comment>()
            .HasData(comments.GenerateBetween(1000, 1000));

            var existingRatings = new HashSet<(int UserId, int AttractionId)>();

            foreach (var rating in ratings.GenerateBetween(500, 500))
            {
                if (!existingRatings.Add((rating.UserId, rating.AttractionId)))
                {
                    continue;
                }
                modelBuilder.Entity<Rating>().HasData(rating);
            }


           
        }
    }
}
