using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    [Table("Reward")]
    public partial class Reward
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [StringLength(200)]
        public string? Description { get; set; }
        [Column(TypeName = "smallmoney")]
        public decimal Price { get; set; }
        public int? Stock { get; set; }
        public int ProjectId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Delivery { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }

        [ForeignKey("ProjectId")]
        [InverseProperty("Rewards")]
        public virtual Project Project { get; set; } = null!;
    }
}
