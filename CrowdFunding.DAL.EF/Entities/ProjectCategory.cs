using CrowdFunding.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CrowdFunding.DAL
{
    public partial class ProjectCategory : IEntity<int>
    {
        public ProjectCategory()
        {
            Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Project> Projects { get; set; }
    }
}
