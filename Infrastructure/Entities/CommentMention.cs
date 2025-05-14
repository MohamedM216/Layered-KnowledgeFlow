public class CommentMention
{
    public int Id { get; set; }
    
    // Foreign keys
    public int CommentId { get; set; }
    public int MentionedUserId { get; set; }
    public int MentionPosition { get; set; } // Position in the content where mention occurs
    public int MentionLength { get; set; } // Length of the mention in the content
    
    // Navigation properties
    public Comment Comment { get; set; }
    public User MentionedUser { get; set; }
}