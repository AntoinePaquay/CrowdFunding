namespace CrowdFunding.API.Models
{
    public class Reward
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? Stock { get; set; }
        public int ProjectId { get; set; }
        public DateTime? Delivery { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }

    public class RewardForm
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? Stock { get; set; }
        public int ProjectId { get; set; }
        public DateTime? Delivery { get; set; }
    }
}
