using CrowdFunding.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.DAL.EF.Interfaces
{
    public interface IProjectStatusHistoryRepository : IRepository<int, ProjectStatusHistory>
    {
    }
}
