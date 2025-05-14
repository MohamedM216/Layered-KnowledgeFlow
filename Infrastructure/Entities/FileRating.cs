public class FileRating
{
    public int Id { get; set; }
    public int RatingValue { get; set; } // 1-5
    public DateTime RatedOn { get; set; } = DateTime.UtcNow;
    
    // Foreign keys
    public int RaterId { get; set; }
    public int FileId { get; set; }
    
    // Navigation properties
    public User Rater { get; set; }
    public File File { get; set; }
}