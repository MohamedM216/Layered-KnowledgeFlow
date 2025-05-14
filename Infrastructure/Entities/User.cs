public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; } // Store hashed passwords only!
    public string ContactEmail { get; set; }
    public string ProfileImagePath { get; set; }
    public string Bio { get; set; }
    public DateTime MembershipDate { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public ICollection<File> Files { get; set; }
    public ICollection<UserRating> RatingsGiven { get; set; }
    public ICollection<UserRating> RatingsReceived { get; set; }
    public ICollection<FileRating> FileRatings { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<UserReview> ReviewsGiven { get; set; }
    public ICollection<UserReview> ReviewsReceived { get; set; }
}