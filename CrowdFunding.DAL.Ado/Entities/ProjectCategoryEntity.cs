using CrowdFunding.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.DAL.Entities
{
    public partial class ProjectCategoryEntity : IEntity<int>
    {
        public int Id { get; set; }
        public string Name = null!;        
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
