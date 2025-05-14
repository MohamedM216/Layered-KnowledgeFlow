public class UserReview
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedOn { get; set; }
    
    // Foreign keys
    public int ReviewerId { get; set; } // User who wrote the review
    public int ReviewedUserId { get; set; } // User who received the review
    
    // Navigation properties
    public User Reviewer { get; set; }
    public User ReviewedUser { get; set; }
}