using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    [Table("Project")]
    public partial class Project
    {
        public Project()
        {
            Articles = new HashSet<Article>();
            Comments = new HashSet<Comment>();
            Rewards = new HashSet<Reward>();
            Transactions = new HashSet<Transaction>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(150)]
        public string Name { get; set; } = null!;
        [StringLength(500)]
        public string? Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Opening { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Closing { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModified { get; set; }
        public int MemberId { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("Projects")]
        public virtual ProjectCategory Category { get; set; } = null!;
        [ForeignKey("MemberId")]
        [InverseProperty("Projects")]
        public virtual Member Member { get; set; } = null!;
        [InverseProperty("Project")]
        public virtual ICollection<Article> Articles { get; set; }
        [InverseProperty("Project")]
        public virtual ICollection<Comment> Comments { get; set; }
        [InverseProperty("Project")]
        public virtual ICollection<Reward> Rewards { get; set; }
        [InverseProperty("Project")]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
