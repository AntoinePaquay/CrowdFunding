using CrowdFunding.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CrowdFunding.DAL
{
    public partial class ProjectStatusHistory : IEntity<int>
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int ProjectStatusId { get; set; }
        public DateTime? Created { get; set; }

        public virtual Project Project { get; set; } = null!;
        public virtual ProjectStatus ProjectStatus { get; set; } = null!;
    }
}
