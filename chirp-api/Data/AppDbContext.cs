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
        // Like: PostId and CommentId are optional (one must be set, not both)
        modelBuilder.Entity<Like>()
            .Property(l => l.PostId)
            .IsRequired(false);

        modelBuilder.Entity<Like>()
            .Property(l => l.CommentId)
            .IsRequired(false);

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
    }
}
