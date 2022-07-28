﻿using CrowdFunding.BLL.Entities;
using CrowdFunding.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Interfaces
{
    public interface IProjectService: IRepository<int, ProjectEntity>
    {
    }
}
