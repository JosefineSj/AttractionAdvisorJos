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
        }
    }
}
