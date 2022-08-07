using CrowdFunding.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CrowdFunding.DAL
{
    public partial class Comment : IEntity<int>
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public int MemberId { get; set; }
        public int ProjectId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? LastModified { get; set; }

        public virtual Member Member { get; set; } = null!;
        public virtual Project Project { get; set; } = null!;
    }
}
