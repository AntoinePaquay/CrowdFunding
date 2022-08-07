using CrowdFunding.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CrowdFunding.DAL
{
    public partial class Member : IEntity<int>
    {
        public Member()
        {
            Comments = new HashSet<Comment>();
            Pledges = new HashSet<Pledge>();
            PrivateMessageRecipients = new HashSet<PrivateMessage>();
            PrivateMessageSenders = new HashSet<PrivateMessage>();
            Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string? Image { get; set; }
        public int CountryId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? LastLogin { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Pledge> Pledges { get; set; }
        public virtual ICollection<PrivateMessage> PrivateMessageRecipients { get; set; }
        public virtual ICollection<PrivateMessage> PrivateMessageSenders { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
