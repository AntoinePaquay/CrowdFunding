using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class RewardMappers
    {
        public static BLL.RewardEntity ToBLL(DAL.RewardEntity e)
        {
            return new BLL.RewardEntity()
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

        public static DAL.RewardEntity ToDAL(BLL.RewardEntity e)
        {
            return new DAL.RewardEntity()
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
