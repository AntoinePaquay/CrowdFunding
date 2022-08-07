using CrowdFunding.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CrowdFunding.DAL
{
    public partial class Reward : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? Stock { get; set; }
        public int ProjectId { get; set; }
        public DateTime? Delivery { get; set; }
        public DateTime? Created { get; set; }

        public virtual Project Project { get; set; } = null!;
    }
}
