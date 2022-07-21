using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    [Table("Member")]
    [Index("Email", Name = "UK_Member_Email", IsUnique = true)]
    [Index("Username", Name = "UK_Member_Username", IsUnique = true)]
    public partial class Member
    {
        public Member()
        {
            Comments = new HashSet<Comment>();
            Projects = new HashSet<Project>();
            Transactions = new HashSet<Transaction>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string LastName { get; set; } = null!;
        [StringLength(100)]
        public string FirstName { get; set; } = null!;
        [StringLength(35)]
        public string Username { get; set; } = null!;
        [StringLength(320)]
        public string Email { get; set; } = null!;
        [StringLength(97)]
        [Unicode(false)]
        public string PasswordHash { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string? Image { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime RegisterDate { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }

        [InverseProperty("Member")]
        public virtual ICollection<Comment> Comments { get; set; }
        [InverseProperty("Member")]
        public virtual ICollection<Project> Projects { get; set; }
        [InverseProperty("Member")]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
