namespace CrowdFunding.API.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public int MemberId { get; set; }
        public int ProjectId { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }

    public class CommentForm
    {
        public string? Text { get; set; }
        public int MemberId { get; set; }
        public int ProjectId { get; set; }
    }
}
