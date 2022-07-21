using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    [Table("Article")]
    public partial class Article
    {
        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        [StringLength(4000)]
        public string? Text { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }

        [ForeignKey("ProjectId")]
        [InverseProperty("Articles")]
        public virtual Project Project { get; set; } = null!;
    }
}
