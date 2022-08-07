using CrowdFunding.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CrowdFunding.DAL
{
    public partial class Article : IEntity<int>
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? Name { get; set; }
        public string? Text { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? LastModified { get; set; }

        public virtual Project Project { get; set; } = null!;
    }
}
