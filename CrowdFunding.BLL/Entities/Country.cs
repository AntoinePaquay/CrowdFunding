using CrowdFunding.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL 
{ 
    public class Country : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
