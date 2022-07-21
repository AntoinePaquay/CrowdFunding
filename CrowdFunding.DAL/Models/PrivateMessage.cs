using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    [Table("PrivateMessage")]
    public partial class PrivateMessage
    {
        [Key]
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        [StringLength(1000)]
        public string? Text { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
