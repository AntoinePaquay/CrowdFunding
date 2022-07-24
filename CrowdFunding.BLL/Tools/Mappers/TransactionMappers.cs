using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Mappers
{
    public static class TransactionMappers
    {
        public static BLL.Entities.TransactionEntity ToBLL(this DAL.Entities.TransactionEntity e)
        {
            return new BLL.Entities.TransactionEntity()
            {
                Id = e.Id,
                MemberId = e.MemberId,
                ProjectId = e.ProjectId,
                Amount = e.Amount,
                Created = e.Created,
                LastModified = e.LastModified,
            };
        }

        public static DAL.Entities.TransactionEntity ToDAL(this BLL.Entities.TransactionEntity e)
        {
            return new DAL.Entities.TransactionEntity()
            {
                Id = e.Id,
                MemberId = e.MemberId,
                ProjectId = e.ProjectId,
                Amount = e.Amount,
                Created = e.Created,
                LastModified = e.LastModified,
            };
        }
    }
}
