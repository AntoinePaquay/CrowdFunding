﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.DAL.Interfaces
{
    public interface IEntity<Tkey>
    {
        public Tkey Id { get; set; }
    }
}
