namespace CrowdFunding.API.Models
{
    public class Article
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? Text { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }

    public class ArticleForm
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? Text { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
