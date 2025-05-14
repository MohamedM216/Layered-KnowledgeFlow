public class File
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public string StoragePath { get; set; } // Path where file is stored
    public string Description { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedOn { get; set; }
    
    // Foreign keys
    public int AuthorId { get; set; }
    
    // Navigation properties
    public User Author { get; set; }
    public ICollection<FileRating> Ratings { get; set; }
    public ICollection<Comment> Comments { get; set; }
}