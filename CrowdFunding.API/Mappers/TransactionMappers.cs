using CrowdFunding.API.Models;

namespace CrowdFunding.API.Mappers
{
    public static class TransactionMappers
    {
        public static Transaction ToModel(this BLL.Entities.TransactionEntity e)
        {
            return new Transaction
            {
                Id = e.Id,
                MemberId = e.MemberId,
                ProjectId = e.ProjectId,
                Amount = e.Amount,
                Created = e.Created,
                LastModified = e.LastModified
            };
        }

        public static BLL.Entities.TransactionEntity ToBLL(this TransactionForm e)
        {
            return new BLL.Entities.TransactionEntity
            {
                Id = e.Id,
                MemberId = e.MemberId,
                ProjectId = e.ProjectId,
                Amount = e.Amount,
            };
        }
    }
}
