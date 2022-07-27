using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Mappers
{
    public static class RewardMappers
    {
        public static BLL.Entities.RewardEntity ToBLL(this DAL.Entities.RewardEntity e)
        {
            return new BLL.Entities.RewardEntity()
            {
                Id = e.Id,
                ProjectId = e.ProjectId,
                Created = e.Created,
                Delivery = e.Delivery,
                Description = e.Description,
                LastModified = e.LastModified,
                Name = e.Name,
                Price = e.Price,
                Stock = e.Stock
            };
        }

        public static DAL.Entities.RewardEntity ToDAL(this BLL.Entities.RewardEntity e)
        {
            return new DAL.Entities.RewardEntity()
            {
                Id = e.Id,
                ProjectId = e.ProjectId,
                Created = e.Created,
                Delivery = e.Delivery,
                Description = e.Description,
                LastModified = e.LastModified,
                Name = e.Name,
                Price = e.Price,
                Stock = e.Stock
            };
        }
    }
}
