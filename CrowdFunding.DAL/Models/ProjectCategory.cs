using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    [Table("ProjectCategory")]
    public partial class ProjectCategory
    {
        public ProjectCategory()
        {
            Projects = new HashSet<Project>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Name { get; set; } = null!;
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<Project> Projects { get; set; }
    }
}
