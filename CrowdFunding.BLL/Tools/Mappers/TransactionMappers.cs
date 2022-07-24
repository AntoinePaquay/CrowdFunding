using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class TransactionMappers
    {
        public static BLL.TransactionEntity ToBLL(this DAL.TransactionEntity e)
        {
            return new BLL.TransactionEntity()
            {
                Id = e.Id,
                MemberId = e.MemberId,
                ProjectId = e.ProjectId,
                Amount = e.Amount,
                Created = e.Created,
                LastModified = e.LastModified,
            };
        }

        public static DAL.TransactionEntity ToDAL(this BLL.TransactionEntity e)
        {
            return new DAL.TransactionEntity()
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
