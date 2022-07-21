using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    [Table("Comment")]
    public partial class Comment
    {
        [Key]
        public int Id { get; set; }
        [StringLength(1000)]
        public string? Text { get; set; }
        public int MemberId { get; set; }
        public int ProjectId { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }

        [ForeignKey("MemberId")]
        [InverseProperty("Comments")]
        public virtual Member Member { get; set; } = null!;
        [ForeignKey("ProjectId")]
        [InverseProperty("Comments")]
        public virtual Project Project { get; set; } = null!;
    }
}
