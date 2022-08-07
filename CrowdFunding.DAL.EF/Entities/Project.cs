using CrowdFunding.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CrowdFunding.DAL
{
    public partial class Project : IEntity<int>
    {
        public Project()
        {
            Articles = new HashSet<Article>();
            Comments = new HashSet<Comment>();
            ParameterHistories = new HashSet<ParameterHistory>();
            Pledges = new HashSet<Pledge>();
            Rewards = new HashSet<Reward>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime Opening { get; set; }
        public DateTime Closing { get; set; }
        public decimal? Goal { get; set; }
        public int MemberId { get; set; }
        public int ProjectCategoryId { get; set; }
        public int ProjectStatusId { get; set; }
        public DateTime? Created { get; set; }

        public virtual Member Member { get; set; } = null!;
        public virtual ProjectCategory ProjectCategory { get; set; } = null!;
        public virtual ProjectStatus ProjectStatus { get; set; } = null!;
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ParameterHistory> ParameterHistories { get; set; }
        public virtual ICollection<Pledge> Pledges { get; set; }
        public virtual ICollection<Reward> Rewards { get; set; }
    }
}
