using CrowdFunding.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CrowdFunding.DAL
{
    public partial class Country : IEntity<int>
    {
        public Country()
        {
            Members = new HashSet<Member>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Member> Members { get; set; }
    }
}
