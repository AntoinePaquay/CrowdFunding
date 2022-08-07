using CrowdFunding.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CrowdFunding.DAL
{
    public partial class PrivateMessage : IEntity<int>
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public string Text { get; set; } = null!;
        public DateTime? Created { get; set; }

        public virtual Member Recipient { get; set; } = null!;
        public virtual Member Sender { get; set; } = null!;
    }
}
