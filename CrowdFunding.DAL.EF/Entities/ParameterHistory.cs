using CrowdFunding.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CrowdFunding.DAL
{
    public partial class ParameterHistory : IEntity<int>
    {
        public int Id { get; set; }
        public DateTime Closing { get; set; }
        public decimal? Goal { get; set; }
        public int ProjectId { get; set; }
        public DateTime? Created { get; set; }

        public virtual Project Project { get; set; } = null!;
    }
}
