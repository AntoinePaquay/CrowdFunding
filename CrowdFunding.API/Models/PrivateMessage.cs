namespace CrowdFunding.API.Models
{
    public class PrivateMessage
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public string? Text { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }


    public class PrivateMessageForm
    {
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public string? Text { get; set; }
    }
}
