public class UserRating
{
    public int Id { get; set; }
    public int RatingValue { get; set; } // 1-5
    public DateTime RatedOn { get; set; } = DateTime.UtcNow;
    
    // Foreign keys
    public int RaterId { get; set; } // User who gave the rating
    public int RatedUserId { get; set; } // User who received the rating
    
    // Navigation properties
    public User Rater { get; set; }
    public User RatedUser { get; set; }
}