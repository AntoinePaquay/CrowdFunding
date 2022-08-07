using CrowdFunding.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.DAL.Interfaces
{
    public interface IParameterHistoryRepository : IRepository<int, ParameterHistory>
    {
    }
}
