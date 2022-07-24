using CrowdFunding_Api_Ado.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class ProjectCategoryEntity : IEntity<int>
    {
        public int Id { get; set; }
        public string Name = null!;        
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
