namespace CrowdFunding.API.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime Opening { get; set; }
        public DateTime Closing { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? LastModified { get; set; }
        public int MemberId { get; set; }
        public int CategoryId { get; set; }
    }

    public class ProjectForm
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime Opening { get; set; }
        public DateTime Closing { get; set; }
        public int MemberId { get; set; }
        public int CategoryId { get; set; }
    }
}
