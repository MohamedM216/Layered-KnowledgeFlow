public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedOn { get; set; }
    
    // Foreign keys
    public int AuthorId { get; set; }
    public int FileId { get; set; }
    
    // Navigation properties
    public User Author { get; set; }
    public File File { get; set; }
}