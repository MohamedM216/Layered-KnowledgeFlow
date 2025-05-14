using Microsoft.EntityFrameworkCore;
using Infrastructure.Entities;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Infrastructure.Entities.File> Files { get; set; }
    public DbSet<UserRating> UserRatings { get; set; }
    public DbSet<FileRating> FileRatings { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<CommentMention> CommentMentions { get; set; }
    public DbSet<UserReview> UserReviews { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // User configurations
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();
            
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
            
        // UserRating configurations - prevent self-rating
        modelBuilder.Entity<UserRating>()
            .ToTable(t => t.HasCheckConstraint("CK_UserRating_NotSelfRating", "[RaterId] <> [RatedUserId]"));;
            
        // UserReview configurations - prevent self-review
        modelBuilder.Entity<UserReview>()
            .ToTable(t => t.HasCheckConstraint("CK_UserReview_NotSelfReview", "[ReviewerId] <> [ReviewedUserId]"));
            
        // FileRating configurations
        modelBuilder.Entity<FileRating>()
            .HasIndex(fr => new { fr.RaterId, fr.FileId })
            .IsUnique();
            
        // UserRating unique constraint
        modelBuilder.Entity<UserRating>()
            .HasIndex(ur => new { ur.RaterId, ur.RatedUserId })
            .IsUnique();
            
        // Set up relationships
        modelBuilder.Entity<Infrastructure.Entities.File>()
            .HasOne(f => f.Author)
            .WithMany(u => u.Files)
            .HasForeignKey(f => f.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);
            
        modelBuilder.Entity<UserRating>()
            .HasOne(ur => ur.Rater)
            .WithMany(u => u.RatingsGiven)
            .HasForeignKey(ur => ur.RaterId)
            .OnDelete(DeleteBehavior.Restrict);
            
        modelBuilder.Entity<UserRating>()
            .HasOne(ur => ur.RatedUser)
            .WithMany(u => u.RatingsReceived)
            .HasForeignKey(ur => ur.RatedUserId)
            .OnDelete(DeleteBehavior.Restrict);
            
        modelBuilder.Entity<FileRating>()
            .HasOne(fr => fr.Rater)
            .WithMany(u => u.FileRatings)
            .HasForeignKey(fr => fr.RaterId)
            .OnDelete(DeleteBehavior.Restrict);
            
        modelBuilder.Entity<FileRating>()
            .HasOne(fr => fr.File)
            .WithMany(f => f.Ratings)
            .HasForeignKey(fr => fr.FileId)
            .OnDelete(DeleteBehavior.Cascade);
            
        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Author)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);
            
        modelBuilder.Entity<Comment>()
            .HasOne(c => c.File)
            .WithMany(f => f.Comments)
            .HasForeignKey(c => c.FileId)
            .OnDelete(DeleteBehavior.Cascade);

        // Comment reply relationship (self-referencing)
        modelBuilder.Entity<Comment>()
            .HasOne(c => c.ParentComment)
            .WithMany(c => c.Replies)
            .HasForeignKey(c => c.ParentCommentId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<CommentMention>()
            .HasOne(cm => cm.Comment)
            .WithMany(c => c.Mentions)
            .HasForeignKey(cm => cm.CommentId)
            .OnDelete(DeleteBehavior.Cascade);
            
        modelBuilder.Entity<CommentMention>()
            .HasOne(cm => cm.MentionedUser)
            .WithMany()
            .HasForeignKey(cm => cm.MentionedUserId)
            .OnDelete(DeleteBehavior.Restrict);
            
        modelBuilder.Entity<UserReview>()
            .HasOne(ur => ur.Reviewer)
            .WithMany(u => u.ReviewsGiven)
            .HasForeignKey(ur => ur.ReviewerId)
            .OnDelete(DeleteBehavior.Restrict);
            
        modelBuilder.Entity<UserReview>()
            .HasOne(ur => ur.ReviewedUser)
            .WithMany(u => u.ReviewsReceived)
            .HasForeignKey(ur => ur.ReviewedUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}