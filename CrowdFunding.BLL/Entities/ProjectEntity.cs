using CrowdFunding.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Entities
{
    public class ProjectEntity : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime Opening { get; set; }
        public DateTime Closing { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? LastModified { get; set; }
        public int MemberId { get; set; }
        public int CategoryId { get; set; }
    }
}
