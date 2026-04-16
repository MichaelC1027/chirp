using chirp_api.Models;
using Microsoft.EntityFrameworkCore;

namespace chirp_api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Follow> Follows { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // Prevent a user from liking the same post or comment twice
        modelBuilder.Entity<Like>()
            .HasIndex(l => new { l.UserId, l.PostId })
            .IsUnique()
            .HasFilter("\"PostId\" IS NOT NULL");

        modelBuilder.Entity<Like>()
            .HasIndex(l => new { l.UserId, l.CommentId })
            .IsUnique()
            .HasFilter("\"CommentId\" IS NOT NULL");

        // Prevent duplicate follows
        modelBuilder.Entity<Follow>()
            .HasIndex(f => new { f.FollowerId, f.FollowingId })
            .IsUnique();
        
        //check for duplicate usernames and emails
        modelBuilder.Entity <User>()
            .HasIndex(u => u.Username).IsUnique();
        
        modelBuilder.Entity <User>()
            .HasIndex(u => u.Email).IsUnique();
        
        /*cascade deleting*/
        // Post -> User
        modelBuilder.Entity<Post>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Comment -> User
        modelBuilder.Entity<Comment>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Comment -> Post
        modelBuilder.Entity<Comment>()
            .HasOne<Post>()
            .WithMany()
            .HasForeignKey(c => c.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        // Like -> User
        modelBuilder.Entity<Like>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Like -> Post (nullable)
        modelBuilder.Entity<Like>()
            .HasOne<Post>()
            .WithMany()
            .HasForeignKey(l => l.PostId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

        // Like -> Comment (nullable)
        modelBuilder.Entity<Like>()
            .HasOne<Comment>()
            .WithMany()
            .HasForeignKey(l => l.CommentId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

        // Follow -> User (follower side)
        modelBuilder.Entity<Follow>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(f => f.FollowerId)
            .OnDelete(DeleteBehavior.Cascade);

        // Follow -> User (following side)
        modelBuilder.Entity<Follow>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(f => f.FollowingId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
