public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedOn { get; set; }
    
    // Foreign keys
    public int AuthorId { get; set; }
    public int FileId { get; set; }
    public int? ParentCommentId { get; set; } // For replies
    
    // Navigation properties
    public User Author { get; set; }
    public File File { get; set; }
    public Comment ParentComment { get; set; } // The original comment being replied to
    public ICollection<Comment> Replies { get; set; } // All replies to this comment
    public ICollection<CommentMention> Mentions { get; set; } // Users mentioned in this comment
}