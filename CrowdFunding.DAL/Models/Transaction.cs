using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    [Table("Transaction")]
    public partial class Transaction
    {
        [Key]
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int ProjectId { get; set; }
        [Column(TypeName = "smallmoney")]
        public decimal Amount { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }

        [ForeignKey("MemberId")]
        [InverseProperty("Transactions")]
        public virtual Member Member { get; set; } = null!;
        [ForeignKey("ProjectId")]
        [InverseProperty("Transactions")]
        public virtual Project Project { get; set; } = null!;
    }
}
