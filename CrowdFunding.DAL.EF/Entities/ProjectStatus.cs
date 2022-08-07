using CrowdFunding.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CrowdFunding.DAL
{
    public partial class ProjectStatus : IEntity<int>
    {
        public ProjectStatus()
        {
            Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
